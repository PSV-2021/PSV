using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Integration.Model;
using Integration.Repository.Interfaces;
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
            dbContext.DrugstoreFeedbacks.ToList().ForEach(feedback =>
                result.Add(new DrugstoreFeedback(feedback.Id, feedback.DrugstoreToken, feedback.Content,
                feedback.Response, feedback.SentTime, feedback.RecievedTime)));
            return result;
        }

        public DrugstoreFeedback GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(DrugstoreFeedback newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(DrugstoreFeedback editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
