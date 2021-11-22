using System;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;

namespace Hospital.MedicalRecords.Service
{
    class UserFeedbackService
    {
        private IUserFeedbackRepository UserFeedbackRepository { get; set; }
        public UserFeedbackService()
        {
            UserFeedbackRepository = new UserFeedbackSqlRepository();
        }
        public Boolean SaveUserFeedback(UserFeedback newUserFeedback)
        {
            return UserFeedbackRepository.Save(newUserFeedback);
        }
    }
}
