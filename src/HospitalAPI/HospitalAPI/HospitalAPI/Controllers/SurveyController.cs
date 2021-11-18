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
        public SurveySqlRepository repoSurvey = new SurveySqlRepository();
        public SurveyService surveyService;

        public SurveyController(MyDbContext db)
        {
            this.dbContext = db;
            surveyService = new SurveyService(new SurveySqlRepository(db));
        }

        [HttpGet]   // GET 
        public IActionResult Get()
        {
            repoSurveyQuestion.dbContext = dbContext;
            List<SurveyQuestion> result = new List<SurveyQuestion>();
            result = repoSurveyQuestion.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(List<SurveyQuestion> surveyQuestion)
        {
            //repoSurvey.dbContext = dbContext;
            //Survey newSurvey = repoSurvey.CreateSurvey(surveyQuestion);
            surveyService.CreateSurvey(surveyQuestion);

            return Ok();
        }
    }
}
