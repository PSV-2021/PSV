using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        public void Delete(int id);
        public List<Feedback> GetAll();
        public void Save(Feedback newFeedback);

        public void Update(Feedback feedback);

        public Feedback getById(string reviewId);
    }
}
