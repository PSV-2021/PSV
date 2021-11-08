using Integration.Repository.Sql;
using Integration.Model;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
{
   public class DrugstoreService
    {
        public DrugstoreSqlRepository DrugstoreRepository = new DrugstoreSqlRepository();
        public DrugstoreService(MyDbContext dbContext)
        {
            DrugstoreRepository = new DrugstoreSqlRepository();
            DrugstoreRepository.dbContext = dbContext;
        }

        public DrugstoreService()
        {
            DrugstoreRepository = new DrugstoreSqlRepository();
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
    }
}
