using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Factory;
using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;
namespace Integration.Service
{
    public class DrugstoreFeedbackService
    {
        public DrugstoreFeedbackSqlRepository DrugstoreFeedbackRepository { get; set; }
        public DrugstoreSqlRepository DrugstoreRepository { get; set; }

        public DrugstoreFeedbackService(MyDbContext dbContext)
        {
            DrugstoreFeedbackRepository = new DrugstoreFeedbackSqlRepository();
            DrugstoreRepository = new DrugstoreSqlRepository();
            DrugstoreFeedbackRepository.dbContext = dbContext;
            DrugstoreRepository.dbContext = dbContext;
        }

        public DrugstoreFeedbackService()
        {
            DrugstoreFeedbackRepository = new DrugstoreFeedbackSqlRepository();
        }

        public string GetNewRadnomId()
        {
           return Guid.NewGuid().ToString();
        }

        public bool checkApiKey(string apiKey, MyDbContext dbContext)
        {
            bool found = false;
            foreach (Drugstore h in dbContext.Drugstores.ToList())
            {
                if (h.ApiKey.Equals(apiKey))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

    }
}
