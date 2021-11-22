using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Sql;

namespace Service
{
    public class DrugstoreResponseService
    {
        public FeedbackSqlRepository FeedbackRepository { get; set; }

        public DrugstoreResponseService(MyDbContext dbContext)
        {
            FeedbackRepository = new FeedbackSqlRepository();
            FeedbackRepository.dbContext = dbContext;
        }

        public DrugstoreResponseService()
        {
            FeedbackRepository = new FeedbackSqlRepository();
        }
        public string GetHospitalURL(String name,MyDbContext dbContext)
        {
            foreach (Hospital h  in dbContext.Hospitals.ToList())
            {
                if (h.Name.Equals(name))
                {
                    return h.Url;
                }
            }

            return null;
        }

        public bool checkApiKey(string apiKey)
        {
            bool found = false;
            foreach (Hospital h in FeedbackRepository.dbContext.Hospitals.ToList())
            {
                if (h.ApiKey.Equals(apiKey))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        public string GetNewRadnomId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
