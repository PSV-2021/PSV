using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.Tendering.Model;
using Integration.Tendering.Repository.Interfaces;
using Model.DataBaseContext;

namespace Integration.Tendering.Repository.Sql
{
    public class TenderOfferSqlRepository : ITenderOfferRepository
    {
        public MyDbContext dbContext { get; set; }

        public TenderOfferSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TenderOfferSqlRepository() { }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<TenderOffer> GetAll()
        {
            return dbContext.TenderOffers.ToList();
        }

        public TenderOffer GetOne(string id)
        {
            return dbContext.TenderOffers.Find(id);
        }

        public void Save(TenderOffer newObject)
        {
            dbContext.TenderOffers.Add(newObject);
            dbContext.SaveChanges();
        }

            public void Update(TenderOffer editedObject)
        {
            dbContext.TenderOffers.Update(editedObject);
            dbContext.SaveChanges();
        }
    }
}
