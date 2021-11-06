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
            int maxId = new DrugstoreFeedbackService(DrugstoreFeedbackRepository.dbContext).GetMaxId();
            DrugstoreFeedback dfb = new DrugstoreFeedback(++maxId, pharmacyReview.pharmacyId, pharmacyReview.review, "",
                DateTime.Now, DateTime.MinValue);
            DrugstoreFeedbackRepository.dbContext.DrugstoreFeedbacks.Add(dfb);
            DrugstoreFeedbackRepository.dbContext.SaveChanges();

        }*/

        public int GetMaxId()
        {
            int max = -999;
            foreach (DrugstoreFeedback df in DrugstoreFeedbackRepository.GetAll())
            {
                if (df.Id > max)
                    max = df.Id;
            }

            return max;

        }

    }
}
