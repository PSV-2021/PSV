using Hospital.DTO;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //surveyService = new SurveyService(new SurveySqlRepository(db));
        }

        [HttpGet]   // GET 
        public IActionResult Get()
        {
            repoSurveyQuestion.dbContext = dbContext;
            return Ok(repoSurveyQuestion.GetAll());
        }

        [HttpPost]
        public IActionResult Post(SurveyDTO survey)
        {
            surveyService.CreateSurvey(survey.SurveyQuestions, survey.SurveyAnswers);
            return Ok();
        }
    }
}
