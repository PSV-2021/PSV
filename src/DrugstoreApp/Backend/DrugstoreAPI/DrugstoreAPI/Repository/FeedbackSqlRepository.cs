using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrugstoreAPI.Models;
using Model.DataBaseContext;

namespace Integration.Repository.Sql
{
    public class FeedbackSqlRepository 
    {
        public MyDbContext dbContext { get; set; }

        public FeedbackSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FeedbackSqlRepository()
        {

        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> GetAll()
        {
            List<Feedback> result = dbContext.Feedbacks.ToList();
            return result;
        }

        
    }
}
