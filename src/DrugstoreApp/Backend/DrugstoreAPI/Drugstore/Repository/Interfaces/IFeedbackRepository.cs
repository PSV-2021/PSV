using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        public bool Delete(int id);
        public List<Feedback> GetAll();
        public bool Save(Feedback newFeedback);

        public bool Update(Feedback feedback);

        public Feedback getById(string reviewId);
    }
}
