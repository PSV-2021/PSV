using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.Model;
using Integration_API.Repository.Interfaces;
using Model.DataBaseContext;

namespace Integration.Repository.Sql
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

        public List<DrugstoreOffer> GetAll()
        {
            List<DrugstoreOffer> result = new List<DrugstoreOffer>();

            dbContext.DrugstoreOffers.ToList().ForEach(drugstoreOffer => result.Add(drugstoreOffer));

            return result;
        }



        public void Save(DrugstoreOffer drugstoreOffer)
        {
            try
            {
                Console.WriteLine(drugstoreOffer.Content);
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
            dbContext.DrugstoreOffers.Update(drugstoreOffer);
            dbContext.SaveChanges();
        }

        public DrugstoreOffer GetOne(string id)
        {
         return dbContext.DrugstoreOffers.Find(id);
            
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
