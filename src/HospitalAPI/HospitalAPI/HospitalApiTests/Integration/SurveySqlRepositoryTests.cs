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
using Hospital.Schedule.Model;

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
            context.Add(new SurveyQuestion (1, "How satisfied are you with the work of your doctor?", 0, 0 ));
            context.Add(new SurveyQuestion (2, "How satisfied are you with the work of your doctor?", 0, 0 ));

            SurveyController surveyController = new SurveyController(context);
            IActionResult retVal = surveyController.Get();

            retVal.Equals(Questions());

        }
        
        [Fact]
        public void Post_answers()
        {           
            SetUpDbContext();

            context.Add(new Appointment(11, new DateTime(2021, 12, 07, 16, 30, 00), 30, "All good", false, 1, 2, false, true));
             
            context.Add(new Patient(12, "Milica", "Mikic", "3009998805137", new DateTime(1997, 10, 12), Sex.female, "065245987", "Kisacka 5", "milica@gmail.com",
               "mici97", "mici789", true, BloodType.A, "Nenad", 1, new List<Allergen>())
               );

            var survey = CreateSurvey();

            SurveyController surveyController = new SurveyController(context);

            IActionResult retVal = surveyController.Post(survey,"12", "11");

            retVal.Equals(HttpStatusCode.OK);
        }

        public static IEnumerable<object[]> Questions()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new SurveyQuestion(1, "How satisfied are you with the work of your doctor?", 0, 0) });
            retVal.Add(new object[] { new SurveyQuestion(2, "How satisfied are you with the work of your doctor?", 0, 0) });
            return retVal;
        }

        public static List<AnsweredQuestion> CreateSurvey()
        {
            List<AnsweredQuestion> retVal = new List<AnsweredQuestion>();

            AnsweredQuestion surveyAnswer1 = new AnsweredQuestion(1, "How satisfied are you with the work of your doctor?", 0, 0 );
            AnsweredQuestion surveyAnswer2 = new AnsweredQuestion(2, "How satisfied were you with the time that your doctor spent with you?", 0, 0 );

            retVal.Add(surveyAnswer1);
            retVal.Add(surveyAnswer2);

            return retVal;
        }
    }
}
