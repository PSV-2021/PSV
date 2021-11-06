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

        public bool Save(Feedback newFeedback)
        {
            try
            {
                dbContext.Feedbacks.Add(newFeedback);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(Feedback feedback)
        {
            dbContext.Feedbacks.Update(feedback);
            dbContext.SaveChanges();
            return true;
        }

        public Feedback getById(string reviewId)
        {
            foreach (Feedback fb in dbContext.Feedbacks.ToList())
            {
                if (fb.Id.Equals(reviewId))
                {
                    return fb;
                }
            }

            return null;
        }
        /*
public Feedback getByKey(string id)
{
   foreach (Feedback fb in dbContext.Feedbacks.ToList())
   {
       if (fb..Equals(id))
           return fb;
   }

   return null;
}
*/




    }
}
