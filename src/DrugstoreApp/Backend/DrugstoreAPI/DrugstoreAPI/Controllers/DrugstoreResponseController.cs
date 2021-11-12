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
using DrugstoreAPI.Repository;
using Integration.Repository.Sql;
using Drugstore.Models;
using Service;
using DrugstoreAPI.Models;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")] // /api/DrugstoreFeedbackWithAPI
    [ApiController]
    
    public class DrugstoreResponseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreResponseService drugstoreResponseService = new DrugstoreResponseService();

        
        public DrugstoreResponseController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }
        
        [HttpGet(template: "getAllMyFeedbacks")]
        [ApiKeyAuth]
        public IActionResult TestAPI()
        {
            List<Feedback> retFeedbacks = new List<Feedback>();
            retFeedbacks = this.dbContext.Feedbacks.ToList();
            return Ok(retFeedbacks);
        }

        [HttpPost(template: "new")]
        [ApiKeyAuth]
        public IActionResult Respond(FeedbackResponseDto dto)
        {


            var client = new RestClient(drugstoreResponseService.GetHospitalURL(dto.HospitalName, dbContext));
            var request = new RestRequest("/api/drugstoreresponse", Method.POST);

            HospitalSqlRepository repo = new HospitalSqlRepository(dbContext);
            FeedbackSqlRepository repoFB = new FeedbackSqlRepository(dbContext);

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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Feedback ediFeedback = repoFB.getById(dto.Id);
                ediFeedback.Response = dto.Response;
                repoFB.Update(ediFeedback);
                return Ok();
            }
            else
                return Unauthorized();
            
        }
        

        [HttpPost]
        public IActionResult Post(Feedback newFeedback)
        {


            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                // Can now check if the value is true:
                var value = Request.Headers["ApiKey"];
                foreach(string nesto in value)
                {
                    if (this.checkApiKey(nesto, dbContext))
                    {
                        FeedbackSqlRepository repo = new FeedbackSqlRepository();
                        repo.dbContext = dbContext;

                        repo.Save(newFeedback);

                        return Ok(newFeedback);
                    }
                }
               
            }
                    return Unauthorized();

        }

        public bool checkApiKey(string apiKey, MyDbContext dbContext)
        {
            bool found = false;
            foreach (Hospital h in dbContext.Hospitals.ToList())
            {
                if (h.ApiKey.Equals(apiKey))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
