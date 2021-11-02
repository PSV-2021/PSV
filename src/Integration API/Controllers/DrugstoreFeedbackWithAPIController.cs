using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using Integration_API.Filters;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;

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
            return Ok("This is my secret");
        }

        [HttpGet(template: "hitit")]
        public IActionResult GetT()
        {
            var client = new RestSharp.RestClient("http://localhost:5001");
            var request = new RestRequest("/api/Medicine");
            var response = client.Get<List<string>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<string> result = response.Data;
            result.ForEach(product => Console.WriteLine(product.ToString()));
            return Ok("NAJJACI SMO NAJJACI");
        }
    }
}
