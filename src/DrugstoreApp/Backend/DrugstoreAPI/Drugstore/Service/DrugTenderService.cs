using System;
using System.Collections.Generic;
using System.Linq;
using Drugstore.Models;
using Drugstore.Repository.Sql;
using Syncfusion.XPS;

namespace Drugstore.Service
{
    public class DrugTenderService
    {
        public DrugTenderSqlRepository drugTenderRepository { get; set; }
        public TenderOfferSqlRepository TenderOfferSqlRepository { get; set; }

        public DrugTenderService(MyDbContext dbContext)
        {
            drugTenderRepository = new DrugTenderSqlRepository(dbContext);
            TenderOfferSqlRepository = new TenderOfferSqlRepository(dbContext);
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
        public void RemoveOffer(string id)
        {
            TenderOfferSqlRepository.Delete(id);
        }
        public List<DrugTender> GetOngoingTenders()
        {
            return drugTenderRepository.GetAll().Where(tender => !tender.isFinished).ToList();
        }
        public List<TenderOffer> GetFinshedTenderOffers()
        {
            return TenderOfferSqlRepository.GetAll().Where(tender => !tender.IsActive).ToList();
        }

        public List<TenderOffer> GetOffersForTender(string tenderId)
        {
            return TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == tenderId).ToList();
        }

        public string GenId()
        {
            return Guid.NewGuid().ToString();
        }
        public TenderOffer getTenderOfferById(string id)
        {
            TenderOffer td = TenderOfferSqlRepository.GetOne(id);
            return td;
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
