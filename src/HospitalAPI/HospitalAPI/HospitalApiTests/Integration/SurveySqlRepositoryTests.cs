using Hospital.DTO;
using HospitalAPI;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;
using HospitalAPI.DTO;
using Xunit;

namespace HospitalApiTests.Integration
{
    public class SurveySqlRepositoryTests
    {
        private MyDbContext context;

        private readonly WebApplicationFactory<Startup> factory;

        public SurveySqlRepositoryTests(WebApplicationFactory<Startup> fact)
        {
            factory = fact;
        }

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseInMemoryDatabase("Base");

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public async void Post_survey()
        {
            HttpClient client = factory.CreateClient();
            var survey = CreateSurvey();
            StringContent content = new StringContent(JsonConvert.SerializeObject(survey), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/survey", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public void Get_surveys()
        {
            SetUpDbContext();

            SurveyQuestion surveyQuestion1 = new SurveyQuestion { Id = 1, Text = "How satisfied are you with the work of your doctor?", Rating = 0, QuestionType = 0 };
            SurveyQuestion surveyQuestion2 = new SurveyQuestion { Id = 2, Text = "How satisfied were you with the time that your doctor spent with you?", Rating = 0, QuestionType = 0 };
            SurveyQuestion surveyQuestion3 = new SurveyQuestion { Id = 3, Text = "During this hospital stay, did doctor treat you with courtesy and respect?", Rating = 0, QuestionType = 0 };

            context.AddRange(surveyQuestion1, surveyQuestion2, surveyQuestion3);

            SurveyController surveyController = new SurveyController(context);

            IActionResult retVal = surveyController.Get();

            retVal.Equals(HttpStatusCode.OK);

        }

        [Fact]
        public void Post_answers()
        {           
            SetUpDbContext();

            var survey = CreateSurvey();

            SurveyController surveyController = new SurveyController(context);

            IActionResult retVal = surveyController.Post(survey);

            retVal.Equals(HttpStatusCode.OK);
        }

        public static SurveyDto CreateSurvey()
        {           
            SurveyDto surveyDTO = new SurveyDto
            {              
                SurveyQuestions = CreateSurveyQuestions(),
                SurveyAnswers = CreateSurveyAnswers(),
            };
            return surveyDTO;
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
