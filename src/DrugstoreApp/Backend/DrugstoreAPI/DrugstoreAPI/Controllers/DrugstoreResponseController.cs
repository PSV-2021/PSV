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

        [HttpGet(template: "respond")]
        public IActionResult Respond(FeedbackResponseDto dto)
        {

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("/api/DrugstoreFeedback/secret", Method.POST);

            request.AddJsonBody(new
            {
                Id = dto.Id,
                Response = dto.Response
            });
            //request.AddHeader("ApiKey", )
            IRestResponse response = client.Execute(request);
            var content = response.Content; // {"message":" created."}


            //var client = new RestSharp.RestClient("http://localhost:5000");
            //var request = new RestRequest("/api/DrugstoreFeedback/secret");
            //var response = client.Post<List<string>>(request);
            //Console.WriteLine("Status: " + response.StatusCode.ToString());
            //List<string> result = response.Data;
            //if (result == null) 
            //{
            //    return Unauthorized();
            //}
            //result.ForEach(product => Console.WriteLine(product.ToString()));
            return Ok("Pogodio bolnicu");
        }
    }
}
