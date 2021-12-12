using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Grpc.Net.Client;
using DrugstoreAPI;
using Grpc.Core;
using Microsoft.AspNetCore.Cors;
using Integration.Service;
using Integration.Repository.Sql;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugPurchaseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private DrugstoreService drugstoreService;
       
        public DrugPurchaseController(MyDbContext db)
        {           
            dbContext = db;
            drugstoreService = new DrugstoreService(new DrugstoreSqlRepository(db));
        }

        [EnableCors("MyPolicy")]
        [HttpPut]
        public IActionResult Put(DrugAmountDemandDto demand)
        {
            if (GetDrugstoreProtocol(demand.Name))
            {
                if (drugDemandGrpc(demand))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
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




        }

        [HttpPut("urgent")]
        public IActionResult UrgentPurchase(DrugAmountDemandDto demand)
        {

            if (GetDrugstoreProtocol(demand.Name))
            {
                if (drugPurchaseGrpc(demand))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
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

                        SetApiKeyInHeader(demand, request);

                        SetRequestBody(demand, requestH);

                        IRestResponse responseH = clientH.Execute(requestH);

                        return Ok(responseH.Content);
                    }

                }
                return Unauthorized(false);
            }

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
            var channel = new Channel(GetGrpcDrugstoreLink(), ChannelCredentials.Insecure);
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

        public bool drugPurchaseGrpc(DrugAmountDemandDto demand)
        {
            //var input = new HelloRequest { Name = "world" };
            var input = new DrugRequest { Amount = demand.Amount, Name = demand.Name, PharmacyUrl = demand.PharmacyUrl, ApiKey = GetApiKey(demand) };
            var channel = new Channel(GetGrpcDrugstoreLink(), ChannelCredentials.Insecure);
            var client = new gRPCDrugPurchaseService.gRPCDrugPurchaseServiceClient(channel);

            var response = client.DrugPurchase(input);
            Console.WriteLine("From server: " + response.Message);

            if (response.IsOk)
            {
                var inputH = new DrugRequest { Amount = demand.Amount, Name = demand.Name, PharmacyUrl = demand.PharmacyUrl, ApiKey = GetApiKey(demand) };
                var channelH = new Channel(GetGrpcHospitalLink(), ChannelCredentials.Insecure);
                var clientH = new gRPCDrugPurchaseService.gRPCDrugPurchaseServiceClient(channelH);

                var responseH = clientH.DrugPurchase(inputH);
                Console.WriteLine("From server: " + responseH.Message);

                if (responseH.IsOk)
                {
                    return true;
                }
                return false;
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
        private string GetGrpcDrugstoreLink()
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "127.0.0.1";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "4111";
            string domport = $"{domain}:{port}";

            return domport;
        }

        private string GetGrpcHospitalLink()
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "127.0.0.1";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "4112";
            string domport = $"{domain}:{port}";

            return domport;
        }

        public bool GetDrugstoreProtocol(string name)
        {
            return drugstoreService.GetDrugstoreProtocolByName(name);
        }

    }
}
