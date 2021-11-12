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

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugPurchaseController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public DrugPurchaseController(MyDbContext db)
        {
            this.dbContext = db;
        }


        [HttpPut]
        public IActionResult Put(DrugAmountDemandDto demand)
        {
            var client = new RestClient(demand.PharmacyUrl);
            var request = new RestRequest("/api/drugdemand", Method.POST);

            SetApiKeyInHeader(demand, request);

            SetRequestBody(demand, request);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(Boolean.Parse(response.Content));

            return Unauthorized(false);
        }

        private static void SetRequestBody(DrugAmountDemandDto demand, RestRequest request)
        {
            var body = new
            {
                Name = demand.Name,
                Amount = demand.Amount,
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);
        }

        private void SetApiKeyInHeader(DrugAmountDemandDto demand, RestRequest request)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Url.Equals(demand.PharmacyUrl))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            request.AddHeader("ApiKey", ApiKey);
            request.AddHeader("Content-Type", "application/json");
        }
    }
}
