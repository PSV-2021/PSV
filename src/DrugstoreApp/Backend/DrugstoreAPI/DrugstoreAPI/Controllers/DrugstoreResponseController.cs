using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using DrugstoreAPI.Filters;
using RestSharp;
using DrugstoreAPI.Models;
using DrugstoreAPI.Repository;
using Integration.Repository.Sql;
using Model.DataBaseContext;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")] // /api/DrugstoreFeedbackWithAPI
    [ApiController]
    [ApiKeyAuth]
    public class DrugstoreResponseController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public DrugstoreResponseController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpGet(template: "getAllMyFeedbacks")]
        public IActionResult TestAPI()
        {
            List<Feedback> retFeedbacks = new List<Feedback>();
            retFeedbacks = this.dbContext.Feedbacks.ToList();
            return Ok(retFeedbacks);
        }
        
        [HttpPost(template: "new")]
        public IActionResult Respond(FeedbackResponseDto dto)
        {

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("/api/drugstoreresponse", Method.POST);

            HospitalSqlRepository repo = new HospitalSqlRepository(dbContext);
            FeedbackSqlRepository repoFB = new FeedbackSqlRepository(dbContext);

            //string nesto = repo.GetKeyByName(dto.HospitalName);

            Feedback ediFeedback = repoFB.getById(dto.Id);
            ediFeedback.Response = dto.Response;
            repoFB.Update(ediFeedback);
            

            request.AddHeader("ApiKey", repo.GetKeyByName(dto.HospitalName));
            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                Id = dto.Id,
                Response = dto.Response
            };

            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);

            IRestResponse response = client.Execute(request);

            return Ok(response);
        }
        

        [HttpPost]
        public IActionResult Post(Feedback newFeedback)
        {
            FeedbackSqlRepository repo = new FeedbackSqlRepository();
            repo.dbContext = dbContext;

            repo.Save(newFeedback);

            return Ok(newFeedback);
        }
    }
}
