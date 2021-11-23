using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Repository
{
    public class SurveyQuestionSqlRepository : ISurveyQuestionRepository
    {
        public MyDbContext dbContext { get; set; }

        public SurveyQuestionSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public SurveyQuestionSqlRepository()
        {

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SurveyQuestion> GetAll()
        {
            List<SurveyQuestion> result = new List<SurveyQuestion>();

            dbContext.SurveyQuestion.ToList().ForEach(survey => result.Add(new SurveyQuestion(survey.Id, survey.Text, survey.Rating, survey.QuestionType)));

            return result;
        }

        public SurveyQuestion GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(SurveyQuestion newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(SurveyQuestion editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
