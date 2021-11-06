using System;
using System.Collections.Generic;
using System.Linq;
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

        public DrugstoreFeedbackService(MyDbContext dbContext)
        {
            DrugstoreFeedbackRepository = new DrugstoreFeedbackSqlRepository();
            DrugstoreFeedbackRepository.dbContext = dbContext;
        }

        public DrugstoreFeedbackService()
        {
            DrugstoreFeedbackRepository = new DrugstoreFeedbackSqlRepository();
        }

       /* public int SaveFeedback(NewPharmacyReviewDto pharmacyReview)
        {
            int maxId = new DrugstoreFeedbackService(DrugstoreFeedbackRepository.dbContext).GetNewRadnomId();
            DrugstoreFeedback dfb = new DrugstoreFeedback(++maxId, pharmacyReview.pharmacyId, pharmacyReview.review, "",
                DateTime.Now, DateTime.MinValue);
            DrugstoreFeedbackRepository.dbContext.DrugstoreFeedbacks.Add(dfb);
            DrugstoreFeedbackRepository.dbContext.SaveChanges();

        }*/

        public string GetNewRadnomId()
        {
           return Guid.NewGuid().ToString();
        }

    }
}
