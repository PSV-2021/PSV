using Integration.Model;
using Integration.Repository.Interfaces;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Repository.Sql
{
    public class DrugsConsumptionSqlRepository : IDrugsConsumptionRepository
    {
        public MyDbContext dbContext { get; set; }

        public DrugsConsumptionSqlRepository()
        {
        }

        public DrugsConsumptionSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<DrugConsumed> GetAll()
        {
            List<DrugConsumed> result = new List<DrugConsumed>();
            result = dbContext.DrugsConsumed.ToList();
            return result;
        }

        public void Save(DrugConsumed newObject)
        {
            throw new NotImplementedException();
        }

        public void Update(DrugConsumed editedObject)
        {
            throw new NotImplementedException();
        }

        public DrugConsumed GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
