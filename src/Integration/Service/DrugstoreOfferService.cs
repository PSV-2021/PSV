
using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
{
    public class DrugstoreOfferService
    {
        public DrugstoreOfferRepository drugstoreOfferRepository { get; set; }

        public DrugstoreOfferService(MyDbContext dbContext)
        {
            drugstoreOfferRepository = new DrugstoreOfferRepository();
            drugstoreOfferRepository.dbContext = dbContext;
        }

        public void SaveOffer(DrugstoreOffer offer)
        {
            drugstoreOfferRepository.Save(offer);
        }

    }
}
