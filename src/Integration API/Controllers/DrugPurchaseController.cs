using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Medicines.Model;
using Integration.Model;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Hospital.Medicines.Service;
using Hospital.Medicines.Repository.Sql;
using Grpc.Net.Client;
using DrugstoreAPI;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugPurchaseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugService medicineService;

        public DrugPurchaseController(MyDbContext db)
        {
            this.medicineService = new DrugService();
            dbContext = db;
        }

        [HttpPut]
        public IActionResult Put(DrugAmountDemandDto demand)
        {
            drugDemandGrpc();

            var client = new RestClient(demand.PharmacyUrl);
            var request = new RestRequest("/api/drugDemand", Method.POST);

            SetApiKeyInHeader(demand, request);

            SetRequestBody(demand, request);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(Boolean.Parse(response.Content));

            return Unauthorized(false);
        }

        [HttpPut("urgent")]
        public IActionResult UrgentPurchase(DrugAmountDemandDto demand)
        {
            var client = new RestClient(demand.PharmacyUrl);
            var request = new RestRequest("/api/drugDemand/urgent", Method.POST);

            SetApiKeyInHeader(demand, request);

            SetRequestBody(demand, request);

            IRestResponse response = client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (Boolean.Parse(response.Content))
                {
                    medicineService.AddDrugUrgent(demand.Name, demand.Amount);
                    return Ok(Boolean.Parse(response.Content));
                }
                
            }
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

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", ApiKey);
        }

        static async Task drugDemandGrpc()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(new HelloRequest
            {
                Name = ".NET Conf"
            });
            Console.WriteLine("From server: " + response.Message);
        }
    }
}
