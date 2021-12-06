using System;
using System.Collections.Generic;
using System.Linq;
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
            List<DrugstoreOffer> result = new List<DrugstoreOffer>();

            dbContext.DrugstoreOffers.ToList().ForEach(drugstoreOffer => result.Add(new DrugstoreOffer(drugstoreOffer.Id, drugstoreOffer.Content, drugstoreOffer.Title, drugstoreOffer.StartDate, drugstoreOffer.EndDate, drugstoreOffer.DrugstoreName)));

            return result;
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
