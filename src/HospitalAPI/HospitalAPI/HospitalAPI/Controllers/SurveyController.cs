using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.SharedModel;
using HospitalAPI.DTO;
using Hospital.MedicalRecords.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public SurveyQuestionSqlRepository repoSurveyQuestion = new SurveyQuestionSqlRepository();
        public SurveySqlRepository repoSurvey;
        public SurveyService surveyService;

        public SurveyController(MyDbContext db)
        {
            this.dbContext = db;
            repoSurvey = new SurveySqlRepository(db);
            surveyService = new SurveyService(repoSurvey);
        }

        [HttpGet]   // GET 
        public IActionResult Get()
        {
            repoSurveyQuestion.dbContext = dbContext;
            return Ok(repoSurveyQuestion.GetAll());

        }

        [HttpPost]
        public IActionResult Post(List<AnsweredQuestion> answeredQuestion)
        {
            surveyService.CreateSurvey(answeredQuestion);
            return Ok();
        }
    }
}
