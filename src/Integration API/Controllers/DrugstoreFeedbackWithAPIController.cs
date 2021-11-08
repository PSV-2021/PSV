using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;

using Model.DataBaseContext;
using Integration_API.Filters;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

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

        [HttpGet(template: "hitit")] //Ovo je test gadjanje, ako nema u Hederu ApiKey = HospitalSecretKey vracace da ne da
        public IActionResult GetT()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            string pom = config["LocalUrl"];
            var client = new RestSharp.RestClient(pom); //Ovo se nalazi u appsettings.json
            var request = new RestRequest("/api/Medicine");
            var response = client.Get<List<string>>(request);
            return Ok(response);
        }
    }
}
