using System;
using System.Collections.Generic;
using System.Linq;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;


namespace Drugstore.Repository.Sql
{
    public class DrugTenderSqlRepository : IDrugTenderRepository
    {
        public MyDbContext dbContext { get; set; }

        public DrugTenderSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DrugTenderSqlRepository()
        {

        }

        public List<DrugTender> GetAll()
        {
            List<DrugTender> result = new List<DrugTender>();
            dbContext.DrugTenders.ToList().ForEach(drugTender => result.Add(new DrugTender(drugTender.Id, drugTender.TenderEnd, drugTender.TenderInfo, drugTender.isFinished)));
            return result;
        }

        public DrugTender GetOne(string id)
        {
            return dbContext.DrugTenders.Find(id);
        }

        public void Save(DrugTender newObject)
        {
            dbContext.DrugTenders.Add(newObject);
            dbContext.SaveChanges();
        }

        public void Update(DrugTender editedObject)
        {
            dbContext.DrugTenders.Update(editedObject);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(DrugTender drugTender)
        {
            throw new NotImplementedException();
        }

        bool IDrugTenderRepository.Delete(string id)
        {
            throw new NotImplementedException();
        }

        public DrugTender GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
