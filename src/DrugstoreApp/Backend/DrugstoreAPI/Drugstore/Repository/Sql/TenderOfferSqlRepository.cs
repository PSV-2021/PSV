using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Sql
{
    public class TenderOfferSqlRepository : ITenderOfferRepository
    {
        public MyDbContext dbContext { get; set; }

        public TenderOfferSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TenderOfferSqlRepository() { }


        public List<TenderOffer> GetAll()
        {
            return dbContext.TenderOffers.ToList();
        }

        public TenderOffer GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(TenderOffer drugTender)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TenderOffer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        internal void Save(TenderOffer tenderOffer)
        {
            dbContext.TenderOffers.Add(tenderOffer);
            dbContext.SaveChanges();
        }

        public void Update(TenderOffer drugTender)
        {
            throw new NotImplementedException();
        }
    }
}
