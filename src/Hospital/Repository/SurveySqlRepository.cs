using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Repository
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
            foreach (Survey s in GetAll())
            {
                if (s.AppointmentId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Survey> GetAll()
        {
            List<Survey> result = new List<Survey>();

            dbContext.Survey.ToList().ForEach(survey => result.Add(new Survey(survey.Id, survey.SurveyQuestions, survey.PatientId, survey.Date, survey.AppointmentId)));

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
