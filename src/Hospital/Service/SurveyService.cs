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

        public void CreateSurvey(List<SurveyQuestion> surveyQuestion)
        {
            /*
            if (!CheckIfExistsById(appointmentId))
            {
                return null;
            }*/
            Survey survey = new Survey();
            survey.Id = FindNextId();
            survey.SurveyQuestions = surveyQuestion;
            survey.PatientId = 1;  //Ove vrednosti se moraju posle promeniti
            survey.AppointmentId = 2; //Ove vrednosti se moraju posle promeniti
            survey.Date = DateTime.Now;
            SurveyRepository.CreateSurvey(survey);

        }

        public int FindNextId()
        {
            List<Survey> surveys = SurveyRepository.GetAll().ToList();
 
            return surveys.Count+1;
        }

    }
}
