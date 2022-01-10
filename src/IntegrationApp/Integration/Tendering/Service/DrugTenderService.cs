﻿using System;
using System.Collections.Generic;
using System.Linq;
using Integration.Model;
using Integration.Repository.Sql;
using Integration.Tendering.DTO;
using Integration.Tendering.Model;
using Integration.Tendering.Repository.Sql;
using Model.DataBaseContext;
using Syncfusion.XPS;

namespace Integration.Service
{
    public class DrugTenderService
    {
        public DrugTenderSqlRepository drugTenderRepository { get; set; }
        public TenderOfferSqlRepository TenderOfferSqlRepository { get; set; }
        public DrugstoreSqlRepository drugstoreSqlRepository { get; set; }

        public DrugTenderService(MyDbContext dbContext)
        {
            drugTenderRepository = new DrugTenderSqlRepository(dbContext);
            TenderOfferSqlRepository = new TenderOfferSqlRepository(dbContext);
            drugstoreSqlRepository = new DrugstoreSqlRepository(dbContext);
        }

        public DrugTenderService(TenderOfferSqlRepository repository)
        {
            this.TenderOfferSqlRepository = repository;
        }

        public void Save(DrugTender tender)
        {
            drugTenderRepository.Save(tender);
        }
        public void SaveTenderOffer(TenderOffer tenderOffer)
        {
            TenderOfferSqlRepository.Save(tenderOffer);
        }

        public List<DrugTender> GetOngoingTenders()
        {
            return drugTenderRepository.GetAll().Where(tender => !tender.isFinished).ToList();
        }

        public List<TenderOffer> GetOffersForTender(string tenderId)
        {
            return TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == tenderId).ToList();
        }
        public List<TenderOffer> GetOffersForDrugstore(int drugstoreId)
        {

            return TenderOfferSqlRepository.GetAll().Where(offer => offer.DrugstoreId == drugstoreId).ToList();
        }
        public List<TenderOffer> GetOffersForDrugstoreActive(int drugstoreId)
        {
            
            return TenderOfferSqlRepository.GetAll().Where(offer => offer.DrugstoreId == drugstoreId).ToList();
        }
        public List <TenderChartInfoDTO> GetDrugstoreTenderInfo(DateRange range) {
            List<TenderChartInfoDTO> chartData = new List<TenderChartInfoDTO>();
            List<Drugstore> drugstores = drugstoreSqlRepository.GetAll();
            foreach (Drugstore d in drugstores) {
                chartData.Add(new TenderChartInfoDTO(d.Id, d.Name, GetDrugstoreWins(range, d.Id), GetDrugstoreProfit(range, d.Id), GetDrugstoreParticipations(range, d.Id)));
            }
            return chartData;
        }
        public TenderChartInfoDTO GetSingleDrugstoreTenderInfo(DateRange range, int id)
        {
            List<Drugstore> drugstores = drugstoreSqlRepository.GetAll();
            foreach (Drugstore d in drugstores)
            {
                if(d.Id == id)
                {
                    return new TenderChartInfoDTO(d.Id, d.Name, GetDrugstoreWins(range, d.Id), GetDrugstoreProfit(range, d.Id), GetDrugstoreParticipations(range, d.Id));
                }
            }
            return null;
        }

        private List<DrugTender> GetDateRangeTenders(DateRange range) {
            return drugTenderRepository.GetAll().Where(tender => tender.TenderEnd >= range.From && tender.TenderEnd <= range.To).ToList();
        }

        private double GetDrugstoreProfit(DateRange range, int drugstoreId) {
            List<DrugTender> tenders = GetDateRangeTenders(range);
            double profit = 0;
            foreach (DrugTender dt in tenders) {
                List <TenderOffer> offers = TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == dt.Id && offer.IsAccepted).ToList();
                foreach (TenderOffer te in offers)
                    profit = te.DrugstoreId == drugstoreId ? profit += te.Price : profit;
            }
            return profit;
        }

        private int GetDrugstoreParticipations(DateRange range, int drugstoreId)
        {
            
            List<DrugTender> tenders = GetDateRangeTenders(range);
            int participations = 0;
            foreach (DrugTender dt in tenders)
            {
                List<TenderOffer> offers = TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == dt.Id).ToList();
                foreach (TenderOffer te in offers)
                {
                    if (te.DrugstoreId == drugstoreId) {
                        Console.WriteLine(drugstoreId);
                        participations += 1;
                        break;
                    }
                }
            }
            return participations;
        }

        private int GetDrugstoreWins(DateRange range, int drugstoreId)
        {
            List<DrugTender> tenders = GetDateRangeTenders(range);
            int wins = 0;
            foreach (DrugTender dt in tenders)
            {
                List<TenderOffer> offers = TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == dt.Id && offer.IsAccepted).ToList();
                foreach (TenderOffer te in offers)
                    wins = te.DrugstoreId == drugstoreId ? wins += 1 : wins;
            }
            return wins;
        }

        public string GenId()
        {
            return Guid.NewGuid().ToString();

        }
        public TenderOffer getTenderOfferById(string id)
        {
           return TenderOfferSqlRepository.GetOne(id);
        }

        public void UpdateTenderOffer(TenderOffer tenderOffer)
        {
            TenderOfferSqlRepository.Update(tenderOffer);
        }
        public void UpdateDrugTender(DrugTender tender)
        {
            drugTenderRepository.Update(tender);
        }
        public DrugTender getDrugTenderById(string id)
        {
            return drugTenderRepository.GetOne(id);
        }


    }
}
