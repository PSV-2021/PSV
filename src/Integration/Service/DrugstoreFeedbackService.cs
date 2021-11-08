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

    }
}
