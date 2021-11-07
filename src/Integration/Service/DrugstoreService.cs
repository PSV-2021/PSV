using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Factory;
using Integration.Model;
using Integration.Repository.Sql;
using Integration_API.Model;
using Model.DataBaseContext;
using Npgsql;

namespace Integration.Service
{
   public class DrugstoreService
    {
        public DrugstoreSqlRepository DrugstoreRepository = new DrugstoreSqlRepository();
        public MyDbContext dbContext { get; set; }
  
        public DrugstoreService()
        {
            DrugstoreRepository = new DrugstoreSqlRepository();
            DrugstoreRepository.dbContext = dbContext;
        }

        public int GetMaxId()
        {
            int max = -999;
            foreach (Drugstore ds in DrugstoreRepository.GetAll())
            {
                if (ds.Id > max)
                    max = ds.Id;
            }

            return max;

        }
        public string GetDrugStoreURL(int id,MyDbContext dbContext)
        {
            foreach (Drugstore dg in dbContext.Drugstores.ToList())
            {
                if (dg.Id == id)
                {
                    return dg.Url;
                }
            }

            return null;
        }
    }

}
