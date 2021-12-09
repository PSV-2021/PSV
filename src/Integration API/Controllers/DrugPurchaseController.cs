﻿using Microsoft.AspNetCore.Http;
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
using Grpc.Net.Client;
using DrugstoreAPI;
using Grpc.Core;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugPurchaseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
       
        public DrugPurchaseController(MyDbContext db)
        {           
            dbContext = db;
        }

        [HttpPut]
        public IActionResult Put(DrugAmountDemandDto demand)
        {
            if (drugDemandGrpc(demand))
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }


            //var client = new RestClient(demand.PharmacyUrl);
            //var request = new RestRequest("/api/drugDemand", Method.POST);

            //SetApiKeyInHeader(demand, request);

            //SetRequestBody(demand, request);

            //IRestResponse response = client.Execute(request);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    return Ok(Boolean.Parse(response.Content));

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
                    var clientH = new RestClient(this.GetHospitalLink());
                    var requestH = new RestRequest("/api/drugPurchase/urgent", Method.PUT);

                    //SetApiKeyInHeader(demand, request);

                    SetRequestBody(demand, requestH);

                    IRestResponse responseH = clientH.Execute(requestH);

                    return Ok(responseH.Content);
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

        private string GetApiKey(DrugAmountDemandDto demand)
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
            return ApiKey;
            
        }

        public bool drugDemandGrpc(DrugAmountDemandDto demand)
        {
            //var input = new HelloRequest { Name = "world" };
            var input = new DrugRequest { Amount = demand.Amount, Name = demand.Name, PharmacyUrl = demand.PharmacyUrl, ApiKey = GetApiKey(demand) };
            var channel = new Channel("127.0.0.1:4111", ChannelCredentials.Insecure);
            var client = new gRPCDrugPurchaseService.gRPCDrugPurchaseServiceClient(channel);

            var response = client.DrugDemand(input);
            Console.WriteLine("From server: " + response.Message);

            if (response.IsOk)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return true;
        }

        private string GetHospitalLink()
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "6666";
            string domport = $"http://{domain}:{port}";

            return domport;
        }
        
        //private static async Task drugDemandAsync(HelloRequest input)
        //{
        //    return await 
        //}
    }
}
