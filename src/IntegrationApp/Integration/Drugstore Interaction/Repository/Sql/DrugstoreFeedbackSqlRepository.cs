using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Integration.Model;
using Integration_API.Repository.Interfaces;
using Model.DataBaseContext;
using Npgsql;

namespace Integration.Repository.Sql
{
    public class DrugstoreFeedbackSqlRepository : IDrugstoreFeedbackRepository
    {
        public MyDbContext dbContext { get; set; }

        public DrugstoreFeedbackSqlRepository()
        {
            this.dbContext = dbContext;
        }

        public DrugstoreFeedbackSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<DrugstoreFeedback> GetAll()
        {
            return dbContext.DrugstoreFeedbacks.ToList();
        }

        public DrugstoreFeedback GetOne(string id)
        {
            return dbContext.DrugstoreFeedbacks.Find(id);
        }
        public DrugstoreFeedback GetById(string reviewId)
        {
            foreach (DrugstoreFeedback fb in dbContext.DrugstoreFeedbacks.ToList())
            {
                if (fb.Id.Equals(reviewId))
                {
                    return fb;
                }
            }

            return null;
        }

        public void Save(DrugstoreFeedback newObject)
        {
            throw new NotImplementedException();
        }

        public void Update(DrugstoreFeedback editedObject)
        {
            dbContext.DrugstoreFeedbacks.Update(editedObject);
            dbContext.SaveChanges();
        }

        public void SaveNewFeedback(DrugstoreFeedback feedback)
        {
            dbContext.DrugstoreFeedbacks.Add(feedback);
            dbContext.SaveChanges();
        }
    }
}
