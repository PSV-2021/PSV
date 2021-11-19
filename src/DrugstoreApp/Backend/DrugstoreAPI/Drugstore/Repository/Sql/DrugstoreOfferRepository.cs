using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Sql
{
    public class DrugstoreOfferRepository : IDrugstoreOfferRepository
    {
        public MyDbContext dbContext { get; set; }

        public DrugstoreOfferRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DrugstoreOfferRepository()
        {

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DrugstoreOffer> GetAll()
        {
            throw new NotImplementedException();
        }

        public DrugstoreOffer getById(string offerId)
        {
            throw new NotImplementedException();
        }

        public void Save(DrugstoreOffer drugstoreOffer)
        {
            try
            {
                dbContext.DrugstoreOffers.Add(drugstoreOffer);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(DrugstoreOffer drugstoreOffer)
        {
            throw new NotImplementedException();
        }
    }
}
