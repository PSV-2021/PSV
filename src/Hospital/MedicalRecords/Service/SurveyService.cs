using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;

namespace Hospital.MedicalRecords.Service
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
            bool retVal = false;
            List<Survey> surveys = SurveyRepository.GetAll().ToList();
            foreach (Survey s in surveys)
            {
                if (s.AppointmentId == id)
                    retVal = true;
                
            }
            return retVal;
        }

        public void CreateSurvey(List<int> surveyQuestions, List<int> surveyAnswers)
        {
            /*
            if (!CheckIfExistsById(appointmentId))
            {
                return null;
            }*/
            Survey survey = new Survey();
            survey.PatientId = 1;  //Ove vrednosti se moraju posle promeniti
            survey.Date = DateTime.Now;
            survey.AppointmentId = 3; //Ove vrednosti se moraju posle promeniti
            survey.SurveyQuestions = surveyQuestions;
            survey.SurveyAnswers = surveyAnswers;
            SurveyRepository.CreateSurvey(survey);

        }

    }
}
