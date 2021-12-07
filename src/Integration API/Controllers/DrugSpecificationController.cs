using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Drugs.DTOs;
using Integration.Drugs.Service;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugSpecificationController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private DrugSpecificationService drugSpecificationService = new DrugSpecificationService();

        public DrugSpecificationController(MyDbContext db)
        {
            this.dbContext = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(drugSpecificationService.GetFiles());
        }

        [HttpGet("files")]
        public IActionResult GetRefreshedFiles([FromQuery] string filename)
        {
            drugSpecificationService.DownloadDrugConsumptionReport(filename);
            return Ok(drugSpecificationService.GetFiles());
        }

        [HttpPut]
        public IActionResult Put(DrugSpecificationRequestDTO specRequest)
        {
            var client = new RestClient(specRequest.PharmacyUrl);
            var request = new RestRequest("/api/drugSpecification", Method.POST);

            SetApiKeyInHeader(specRequest, request);
            SetRequestBody(specRequest, request);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(true);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return NoContent();
            return Unauthorized(false);
        }

        private static void SetRequestBody(DrugSpecificationRequestDTO specRequest, RestRequest request)
        {
            var body = new
            {
                Name = specRequest.Name,
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);
        }

        private void SetApiKeyInHeader(DrugSpecificationRequestDTO specRequest, RestRequest request)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Url.Equals(specRequest.PharmacyUrl))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", ApiKey);
        }
    }
}
