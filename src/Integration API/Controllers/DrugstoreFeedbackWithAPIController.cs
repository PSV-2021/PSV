using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_API.Model;
using Model.DataBaseContext;
using Integration_API.Filters;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using Integration;
using Integration.Repository.Sql;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class DrugstoreFeedbackWithAPIController : ControllerBase
    {

        [HttpGet(template:"secret")]   // GET /secret
        public IActionResult Get()
        {
            return Ok("You can use hospital services :)");
        }

        [HttpGet(template: "hitit")]
        public IActionResult HitIt()
        {
            var client = new RestSharp.RestClient("http://localhost:5001");
            var request = new RestRequest("/api/DrugstoreFeedbackWithAPI/secret");
            request.AddHeader("ApiKey", "LJa6p1qNr20saUvj");
            var response = client.Get<List<string>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<string> result = response.Data;
            result.ForEach(product => Console.WriteLine(product.ToString()));
            return Ok("Pogodio apoteku");
        }
    }
}
