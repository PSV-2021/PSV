using Drugstore.Models;
using Drugstore.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Service
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
        public string GetNewRadnomId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
