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
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.Authorization;

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

        [AuthAttributePatient("Get", "patient")]
        [HttpGet]   // GET 
        public IActionResult Get()
        {
            repoSurveyQuestion.dbContext = dbContext;
            return Ok(repoSurveyQuestion.GetAll());

        }

        [AuthAttributePatient("Post", "patient")]
        [HttpPost("{id}/{ap}")]
        public IActionResult Post(List<AnsweredQuestion> answeredQuestion, string id, string ap)
        {
            surveyService.CreateSurvey(answeredQuestion, id, ap);
            return Ok();
        }
    }
}
