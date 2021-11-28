using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.DTO;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Repository
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
        public bool SaveUserFeedback(UserFeedback userFeedback)
        {
            userFeedback.Id = GetAll().Count + 1;
            dbContext.UserFeedbacks.Add(userFeedback);
            dbContext.SaveChanges();
            return true;
        }
        public List<UserFeedback> GetAll()
        {
            List<UserFeedback> result = new List<UserFeedback>();
            dbContext.UserFeedbacks.ToList().ForEach(userFeedbacks => result.Add(userFeedbacks));

            return result;
        }

        public string GetUserFeedback(int id)
        {
            var query = from st in dbContext.UserFeedbacks
                        where st.Id == id
                        select st.Content;
            return query.FirstOrDefault();
        }

        public List<CommentDTO> GetAllAproved()
        {
            var a = dbContext.UserFeedbacks.Where(f => f.canPublish == true);

            List<UserFeedback> list = new List<UserFeedback>();
            list = a.ToList<UserFeedback>();

            List<CommentDTO> result = new List<CommentDTO>();
            foreach ( UserFeedback f in list){
                   result.Add(new CommentDTO{ Name = f.Name, Date = f.TimeWritten, Content = f.Content });
            }

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

