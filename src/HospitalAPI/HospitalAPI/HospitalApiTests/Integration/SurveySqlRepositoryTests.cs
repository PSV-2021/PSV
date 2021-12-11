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
    [Trait("Type", "IntegrationTest")]
    public class SurveySqlRepositoryTests
    {
        private MyDbContext context;

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseInMemoryDatabase("Base");

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Get_surveys()
        {
            SetUpDbContext();
            context.Add(new SurveyQuestion { Id =1, Text = "How satisfied are you with the work of your doctor?", Rating= 0, QuestionType =0 });
            context.Add(new SurveyQuestion { Id = 2, Text = "How satisfied are you with the work of your doctor?", Rating = 0, QuestionType = 0 });

            SurveyController surveyController = new SurveyController(context);
            IActionResult retVal = surveyController.Get();

            retVal.Equals(Questions());

        }
        
        [Fact]
        public void Post_answers()
        {           
            SetUpDbContext();

            var survey = CreateSurvey();

            SurveyController surveyController = new SurveyController(context);

            IActionResult retVal = surveyController.Post(survey,"2", "1");

            retVal.Equals(HttpStatusCode.OK);
        }

        public static IEnumerable<object[]> Questions()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new SurveyQuestion { Id = 1, Text = "How satisfied are you with the work of your doctor?", Rating = 0, QuestionType = 0 } });
            retVal.Add(new object[] { new SurveyQuestion { Id = 2, Text = "How satisfied are you with the work of your doctor?", Rating = 0, QuestionType = 0 } });
            return retVal;
        }

        public static List<AnsweredQuestion> CreateSurvey()
        {
            List<AnsweredQuestion> retVal = new List<AnsweredQuestion>();

            AnsweredQuestion surveyAnswer1 = new AnsweredQuestion { Id = 1, Text = "How satisfied are you with the work of your doctor?", Rating = 0, QuestionType = 0 };
            AnsweredQuestion surveyAnswer2 = new AnsweredQuestion { Id = 2, Text = "How satisfied were you with the time that your doctor spent with you?", Rating = 0, QuestionType = 0 };

            retVal.Add(surveyAnswer1);
            retVal.Add(surveyAnswer2);

            return retVal;
        }
    }
}
