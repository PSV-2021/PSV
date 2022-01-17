using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Linq;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Grpc.Core;
using Microsoft.AspNetCore.Cors;
using Integration.Service;
using Integration.Repository.Sql;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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
            try
            {
                if (GetDrugstoreProtocol(demand.PharmacyUrl))
                {
                    if (drugDemandGrpc(demand))
                    {
                        return Ok(true);
                    }
                    return Ok(false);
                }
                
                
                var client = new RestClient(demand.PharmacyUrl);
                var request = new RestRequest("/api/drugDemand", Method.POST);

                SetApiKeyInHeader(demand, request);

                SetRequestBody(demand, request);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return Ok(Boolean.Parse(response.Content));
                return NotFound("Drugstore not available at the moment!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }

        [HttpPut("urgent")]
        public IActionResult UrgentPurchase(DrugAmountDemandDto demand)
        {
            try
            {
                if (GetDrugstoreProtocol(demand.PharmacyUrl))
                {
                    if (drugPurchaseGrpc(demand))
                    {
                        return Ok(true);
                    }
                    return Ok(false);
                }
            }
            catch (Exception e)
            {
                return NotFound("Drugstore server not available!");
            }

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
            return Unauthorized("You are not authorized for this action.");

        }

        [HttpPost("finish")]
        public IActionResult FinishTender(TenderOfferCompletionDto demand)
        {
            int isOk = 0;
            List<DrugTenderDto> retInfo = this.getDrugToSell(this.DemandToString(demand.TenderInfo));
            int check = retInfo.Count();
            

            foreach (DrugTenderDto d in retInfo)
            {
                
                DrugAmountDemandDto dto = new DrugAmountDemandDto(this.GetHospitalLink(),d.DrugName, d.Amount);
                var client = new RestClient(this.GetHospitalLink());
                var request = new RestRequest("/api/drugPurchase/urgent", Method.PUT);
                SetApiKeyInHeaderForFinish(demand, request);

                SetRequestBody(dto, request);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    isOk++;
                }
                else
                {
                    return Ok(false);
                }
                
            }

            return Ok(true);        

    }
        private string DemandToString(List<DrugTenderDto> list)
        {
            string ret = "";
            foreach (DrugTenderDto dto in list)
            {
                ret += dto.DrugName + " - " + dto.Amount + " , ";
            }
            string fin = ret.Remove(ret.Length - 2, 2);
            return fin;
        }

        private List<DrugTenderDto> getDrugToSell(string info)
        {
            string[] infos = info.Split(",");
            List<DrugTenderDto> retInfo = new List<DrugTenderDto>();
            foreach (string s in infos)
            {
                string[] singleDrugInfo = s.Split("-");
                DrugTenderDto drug = new DrugTenderDto(singleDrugInfo[0].Trim(), int.Parse(singleDrugInfo[1]));
                retInfo.Add(drug);
            }
            return retInfo;
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

        private static void SetRequestBodyForFinish(TenderOfferCompletionDto demand, RestRequest request)
        {
            var body = new
            {
                Id = demand.Id,
                TenderEnd = demand.TenderEnd,
                TenderInfo = demand.TenderInfo,
                IsWinner = demand.IsWinner
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
        private void SetApiKeyInHeaderForFinish(TenderOfferCompletionDto demand, RestRequest request)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Url.Equals(this.GetHospitalLink()))
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
                    return df.ApiKey;
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
            if (response.Message.Contains("unaut"))
            {
                throw new UnauthorizedAccessException();
            }
            return false;
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
            string domain = Environment.GetEnvironmentVariable("HOSPITAL_DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("HOSPITAL_PORT") ?? "5003";
            string domport = $"http://{domain}:{port}";

            return domport;
        }
        private string GetGrpcDrugstoreLink()
        {
            string domain = Environment.GetEnvironmentVariable("DRUGSTORE_GRPC_DOMAIN") ?? "127.0.0.1";
            string port = Environment.GetEnvironmentVariable("DRUGSTORE_GRPC_PORT") ?? "4111";
            string domport = $"{domain}:{port}";

            return domport;
        }

        private string GetGrpcHospitalLink()
        {
            string domain = Environment.GetEnvironmentVariable("HOSPITAL_GRPC_DOMAIN") ?? "127.0.0.1";
            string port = Environment.GetEnvironmentVariable("HOSPITAL_GRPC_PORT") ?? "4112";
            string domport = $"{domain}:{port}";

            return domport;
        }

        public bool GetDrugstoreProtocol(string name)
        {
            return drugstoreService.GetDrugstoreProtocolByName(name);
        }

    }
}
