using Hospital.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository
{
    public interface ISurveyRepository : IGenericRepository<Survey, int>
    {
        public bool CheckIfExistsById(int id);
    }
}
