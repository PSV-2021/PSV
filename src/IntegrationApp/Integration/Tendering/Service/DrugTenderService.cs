﻿using System;
using System.Collections.Generic;
using System.Linq;
using Integration.Repository.Sql;
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

        public List<DrugTender> GetOngoingTenders()
        {
            return drugTenderRepository.GetAll().Where(tender => !tender.isFinished).ToList();
        }

        public List<TenderOffer> GetOffersForTender(string tenderId)
        {
            return TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == tenderId).ToList();
        }

        public string GenId()
        {
            return Guid.NewGuid().ToString();

        }


    }
}
