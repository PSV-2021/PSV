﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Service;
using Integration.Sql;

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
            this.dbContext = db;
            this.medicineService = new DrugService(new DrugSqlRepository(dbContext));
        }

        [HttpPut]
        public IActionResult Put(DrugAmountDemandDto demand)
        {
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
    }
}
