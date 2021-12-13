using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugstore.Repository.Sql
{
    public class DrugSpecificationSqlRespository : IDrugSpecificationRepository
    {

        public MyDbContext dbContext { get; set; }

        public DrugSpecificationSqlRespository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DrugSpecificationSqlRespository()
        {

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DrugSpecification> GetAll()
        {
            List<DrugSpecification> result = new List<DrugSpecification>();

            dbContext.DrugSpecifications.ToList().ForEach(drugSpecification => result.Add(new DrugSpecification(drugSpecification.Name, drugSpecification.Text)));

            return result;
        }

        public DrugSpecification getById(string offerId)
        {
            throw new NotImplementedException();
        }

        public void Save(DrugSpecification drugSpecification)
        {
            throw new NotImplementedException();
        }

        public void Update(DrugSpecification drugSpecification)
        {
            throw new NotImplementedException();
        }
    }
}
