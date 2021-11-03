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

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")] // /api/DrugstoreFeedbackWithAPI
    [ApiController]
    [ApiKeyAuth]
    public class DrugstoreFeedbackWithAPIController : ControllerBase
    {
        [HttpGet(template: "secret")]
        public IActionResult TestAPI()
        {
            return Ok("You can use our drugstore services :)");
        }

        [HttpGet(template: "hitHospital")]
        public IActionResult HitHospital()
        {
            var client = new RestSharp.RestClient("http://localhost:5000");
            var request = new RestRequest("/api/DrugstoreFeedback/testHit");
            var response = client.Get<List<string>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<string> result = response.Data;
            result.ForEach(product => Console.WriteLine(product.ToString()));
            return Ok("Pogodio bolnicu");
        }
    }
}
