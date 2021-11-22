using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Repository
{
    public class SurveySqlRepository : ISurveyRepository
    {
        public MyDbContext dbContext { get; set; }

        public SurveySqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public SurveySqlRepository()
        {

        }

        public bool CheckIfExistsById(int id)
        {
            bool retVal = false;
            foreach (Survey s in GetAll())
            {
                if (s.AppointmentId == id)
                {
                    retVal = true;
                }
            }
            return retVal;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Survey> GetAll()
        {
            List<Survey> result = new List<Survey>();

            dbContext.Survey.ToList().ForEach(survey => result.Add(new Survey(survey.Id, survey.PatientId, survey.Date, survey.AppointmentId, survey.SurveyQuestions, survey.SurveyAnswers)));

            return result;
        }

        public Survey GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Survey newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Survey editedObject)
        {
            throw new NotImplementedException();
        }

        public void CreateSurvey(Survey survey)
        {
            dbContext.Survey.Add(survey);

            dbContext.SaveChanges();
        }
    }
}
