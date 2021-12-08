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

            dbContext.Survey.ToList().ForEach(survey => result.Add(new Survey(survey.PatientId, survey.Date, survey.AppointmentId)));

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

        public void CreateSurvey(List<AnsweredQuestion> answeredQuestion, string id, string ap)
        {
            dbContext.Survey.Add(new Survey { Date = DateTime.Now, PatientId = Int32.Parse(id), AppointmentId = Int32.Parse(ap)});
            dbContext.SaveChanges();

            var a = dbContext.Survey.Max(s => s.Id);

            foreach (AnsweredQuestion answer in answeredQuestion)
            {
                answer.SurveyId = a;
                dbContext.AnsweredQuestion.Add(answer);
            }

            dbContext.SaveChanges();
        }

        public void CreateSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
