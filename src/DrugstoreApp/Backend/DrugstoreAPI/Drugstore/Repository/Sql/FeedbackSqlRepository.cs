using System;
using System.Collections.Generic;
using System.Linq;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Sql
{
    public class FeedbackSqlRepository: IFeedbackRepository
    {
        public MyDbContext dbContext { get; set; }

        public FeedbackSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FeedbackSqlRepository()
        {

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> GetAll()
        {
            List<Feedback> result = dbContext.Feedbacks.ToList();
            return result;
        }

        public void Save(Feedback newFeedback)
        {
            try
            {
                dbContext.Feedbacks.Add(newFeedback);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Feedback feedback)
        {
            dbContext.Feedbacks.Update(feedback);
            dbContext.SaveChanges();
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

    }
}
