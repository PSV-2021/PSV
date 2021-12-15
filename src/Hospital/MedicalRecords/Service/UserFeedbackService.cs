using System;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;

namespace Hospital.MedicalRecords.Service
{
    public class UserFeedbackService
    {
        private IUserFeedbackRepository UserFeedbackRepository { get; set; }
        private UserFeedbackSqlRepository userFeedbackSqlRepository { get; set; }
        public UserFeedbackService()
        {
            UserFeedbackRepository = new UserFeedbackSqlRepository();
        }
        public UserFeedbackService(UserFeedbackSqlRepository userFeedbackSqRepository)
        {
            UserFeedbackRepository = userFeedbackSqRepository;
            userFeedbackSqlRepository = userFeedbackSqRepository;
        }
        public Boolean SaveUserFeedback(UserFeedback newUserFeedback)
        {
            return userFeedbackSqlRepository.SaveUserFeedback(newUserFeedback);
        }
       

    }
}
