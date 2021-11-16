using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Service
{
    public class SurveyService
    {
        private ISurveyRepository SurveyRepository { get; set; }

        public SurveyService(ISurveyRepository surveyRepository)
        {
            SurveyRepository = surveyRepository;
        }

        public bool CheckIfExistsById(int id)
        {
            List<Survey> surveys = SurveyRepository.GetAll().ToList();
            foreach (Survey s in surveys)
            {
                if (s.AppointmentId == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
