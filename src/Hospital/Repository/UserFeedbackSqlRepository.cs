using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Model;
using Repository;

namespace Hospital.Repository
{
    public class UserFeedbackSqlRepository:IUserFeedbackRepository
    {
        public MyDbContext dbContext { get; set; }

        public UserFeedbackSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserFeedbackSqlRepository()
        {

        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserFeedback> GetAll()
        {
            List<UserFeedback> result = new List<UserFeedback>();
            dbContext.UserFeedbacks.ToList().ForEach(userFeedbacks => result.Add(new UserFeedback(userFeedbacks.Id, userFeedbacks.Date, userFeedbacks.Name, userFeedbacks.canPublish, userFeedbacks.Content)));

            return result;
        }

        public string GetUserFeedback(int id)
        {
            var query = from st in dbContext.UserFeedbacks
                        where st.Id == id
                        select st.Content;

            return query.FirstOrDefault();
        }

        public List<UserFeedback> GetAllAproved()
        {
            List<UserFeedback> result = new List<UserFeedback>();
            dbContext.UserFeedbacks.ToList().ForEach(userFeedbacks => result.Add(new UserFeedback(userFeedbacks.Id, userFeedbacks.Date, userFeedbacks.Name, userFeedbacks.canPublish, userFeedbacks.Content)));

            return result;
        }

        public UserFeedback GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(UserFeedback newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserFeedback editedObject)
        {
            throw new NotImplementedException();
        }
    }
}

