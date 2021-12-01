using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DataBaseContext;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public PrescriptionController(MyDbContext db)
        {
            dbContext = db;
        }

        [HttpPost("qr")]
        public IActionResult QrPerscription([FromBody] string file)
        {
            var key = Request.Headers["ApiKey"].FirstOrDefault();
            if (key == null || !key.Equals("abcde"))
                return Unauthorized();

            var url = Request.Headers["Url"].FirstOrDefault();
            if (url == null)
                return BadRequest();

            var name = Request.Headers["Patient"].FirstOrDefault();
            if (Request.Headers["Patient"].FirstOrDefault() == null)
                return BadRequest();

            var client = new RestClient(url);
            var request = new RestRequest("/api/prescription/qr", Method.POST);

            SetApiKeyInHeaderQr(url, name, request);

            request.AddJsonBody(file);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Content);
            }

            return BadRequest("Something went wrong");
        }

        private void SetApiKeyInHeaderQr(string url, string name, RestRequest request)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Url.Equals(url))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", ApiKey);
            request.AddHeader("Patient", name);
        }
    }
}
