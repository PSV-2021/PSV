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
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<DrugstoreFeedback> GetAll()
        {
            List<DrugstoreFeedback> result = new List<DrugstoreFeedback>();
            result = dbContext.DrugstoreFeedbacks.ToList();
            return result;
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

        public bool Save(DrugstoreFeedback newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(DrugstoreFeedback editedObject)
        {
            dbContext.DrugstoreFeedbacks.Update(editedObject);
            dbContext.SaveChanges();
            return true;
        }
    }
}
