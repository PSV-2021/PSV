using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration_API.Repository.File;
using Integration_API.Repository.Interfaces;

namespace Service
{
    class UserFeedbackService
    {
        private IUserFeedbackRepository UserFeedbackRepository { get; set; }
        public UserFeedbackService()
        {
            UserFeedbackRepository = new UserFeedbackFileRepository();
        }
        public Boolean SaveUserFeedback(UserFeedback newUserFeedback)
        {
            return UserFeedbackRepository.Save(newUserFeedback);
        }
    }
}
