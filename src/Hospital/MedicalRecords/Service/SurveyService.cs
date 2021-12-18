using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;

namespace Hospital.MedicalRecords.Service
{
    public class SurveyService
    {
        private SurveySqlRepository SurveyRepository { get; set; }
        private ISurveyRepository ISurveyRepository { get; set; }
        private SurveyQuestionSqlRepository SurveyQuestionRepository { get; set; }

        public SurveyService(SurveySqlRepository surveyRepository)
        {
            SurveyRepository = surveyRepository;
        }

        public SurveyService(ISurveyRepository IsurveyRepository)
        {
            ISurveyRepository = IsurveyRepository;
        }

        public SurveyService(SurveyQuestionSqlRepository SurveyQuestionSqlRepository)
        {
            SurveyQuestionRepository = SurveyQuestionSqlRepository;
        }

        public bool CheckIfExistsById(int id)
        {
            List<Survey> surveys = ISurveyRepository.GetAll().ToList();
            foreach (Survey s in surveys)
            {
                if (s.AppointmentId == id)
                    return true;
                
            }
            return false;
        }

        public void CreateSurvey(List<AnsweredQuestion> answeredQuestion, string id, string ap)
        {
            SurveyRepository.CreateSurvey(answeredQuestion, id, ap);
        }

        public List<SurveyQuestion> GetAll()
        {
            return SurveyQuestionRepository.GetAll();
        }

    }
}
