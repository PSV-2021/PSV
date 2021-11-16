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
        [Fact]
        public void Appointment_id_exist()
        {
            var surveyStubRepository = new Mock<ISurveyRepository>();
            var surveyService = new SurveyService(surveyStubRepository.Object);
            List<Survey> seachedSurvey = GenerateStubData();

            surveyStubRepository.Setup(s => s.GetAll()).Returns(seachedSurvey);

            SurveyService service = new SurveyService(surveyStubRepository.Object);
            bool b = service.CheckIfExistsById(1);
            b.ShouldBeTrue();

        }

        [Fact]
        public void Appointment_id_doesnt_exist()
        {
            var surveyStubRepository = new Mock<ISurveyRepository>();
            var surveyService = new SurveyService(surveyStubRepository.Object);
            List<Survey> seachedSurvey = GenerateStubData();

            surveyStubRepository.Setup(s => s.GetAll()).Returns(seachedSurvey);

            SurveyService service = new SurveyService(surveyStubRepository.Object);
            bool b = service.CheckIfExistsById(3);
            b.ShouldBeFalse();
        }

        private static List<Survey> GenerateStubData()
        {
            List<Survey> surveys = new List<Survey>();
            List<SurveyQuestion> surveyQuestions = CreateSurveyQuestions();

            Survey survey1 = new Survey(1, surveyQuestions, 1, DateTime.Now, 1);
            Survey survey2 = new Survey(2, surveyQuestions, 2, DateTime.Now, 2);

            surveys.Add(survey1);
            surveys.Add(survey2);


            return surveys;
        }

        private static List<SurveyQuestion> CreateSurveyQuestions()
        {
            List<SurveyQuestion> questions = new List<SurveyQuestion>();
            SurveyQuestion surveyQuestion = new SurveyQuestion(1, "Prvo pitanje", 1, 1);
            SurveyQuestion surveyQuestion2 = new SurveyQuestion(2, "Drugo pitanje", 1, 1);
            SurveyQuestion surveyQuestion3 = new SurveyQuestion(3, "Trece pitanje", 1, 1);
            SurveyQuestion surveyQuestion4 = new SurveyQuestion(4, "Cetvrto pitanje", 1, 1);
            SurveyQuestion surveyQuestion5 = new SurveyQuestion(5, "Peto pitanje", 1, 1);

            questions.Add(surveyQuestion);
            questions.Add(surveyQuestion2);
            questions.Add(surveyQuestion3);
            questions.Add(surveyQuestion4);
            questions.Add(surveyQuestion5);

            return questions;
        }
    }
}
