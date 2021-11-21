using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalApiTests.Unit
{
    public class SurveyUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Appointment_id_exist_or_doesnt_exist(int id, bool expectedValue)
        {
            var surveyStubRepository = new Mock<ISurveyRepository>();
            var surveyService = new SurveyService(surveyStubRepository.Object);
            List<Survey> survey = GenerateStubData();

            surveyStubRepository.Setup(s => s.GetAll()).Returns(survey);

            SurveyService service = new SurveyService(surveyStubRepository.Object);
            bool b = service.CheckIfExistsById(id);

            b.ShouldBe(expectedValue);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, true });
            retVal.Add(new object[] { 3, false });
            return retVal;

        }

        private static List<Survey> GenerateStubData()
        {
            List<Survey> surveys = new List<Survey>();
            List<int> surveyQuestions = CreateSurveyQuestions();
            List<int> surveyAnswers = CreateSurveyAnswers();

            Survey survey1 = new Survey(1, 1, DateTime.Now, 1, surveyQuestions, surveyAnswers);
            Survey survey2 = new Survey(2, 1, DateTime.Now, 2, surveyQuestions, surveyAnswers);

            surveys.Add(survey1);
            surveys.Add(survey2);


            return surveys;
        }

        private static List<int> CreateSurveyQuestions()
        {
            List<int> questions = new List<int>();

            questions.Add(1);
            questions.Add(2);
            questions.Add(3);
            questions.Add(4);
            questions.Add(5);
            questions.Add(6);
            questions.Add(7);
            questions.Add(8);
            questions.Add(9);
            questions.Add(10);
            questions.Add(11);
            questions.Add(12);
            questions.Add(13);
            questions.Add(14); 

            return questions;
        }

        private static List<int> CreateSurveyAnswers()
        {
            List<int> questions = new List<int>();

            questions.Add(1);
            questions.Add(2);
            questions.Add(3);
            questions.Add(4);
            questions.Add(5);
            questions.Add(1);
            questions.Add(2);
            questions.Add(3);
            questions.Add(4);
            questions.Add(5);
            questions.Add(1);
            questions.Add(2);
            questions.Add(3);
            questions.Add(4);

            return questions;
        }

    }
}
