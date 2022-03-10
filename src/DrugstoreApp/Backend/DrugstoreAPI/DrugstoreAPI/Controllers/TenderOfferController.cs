using Drugstore.Models;
using Drugstore.Service;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.DTOs;
using DrugstoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOfferController : Controller
    {
        private string host = Environment.GetEnvironmentVariable("RABBIT_HOST") ?? "localhost";
        private readonly MyDbContext dbContext;
        public DrugTenderService drugTenderService;
        public MedicineService medicineService;
        public TenderOfferController(MyDbContext db) 
        {
            this.dbContext = db;
        }
        [HttpPost]
        public IActionResult Post(TenderOffer offer)
        {
            drugTenderService = new DrugTenderService(dbContext);
            var factory = new ConnectionFactory() { HostName = host };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tenderOffer", type: ExchangeType.Direct);
                string tenderId = drugTenderService.GenId();
                TenderOffer tenderOffer = new TenderOffer(tenderId, offer.TenderOfferInfo, offer.Price, offer.TenderId, offer.IsAccepted, offer.DrugstoreId, offer.IsActive);
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(tenderOffer);
                var bodyNew = Encoding.UTF8.GetBytes(jsonBody);
                channel.BasicPublish(exchange: "tenderOffer",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: bodyNew);
                drugTenderService.SaveTenderOffer(tenderOffer);

                return Ok(true);


            }
        }



        [HttpGet("ongoing")] // Get /api/tenderOffer/ongoing
        public IActionResult GetOnGoing()
        {
            drugTenderService = new DrugTenderService(dbContext);
            List<TenderDto> retVal = new List<TenderDto>();
            try
            {
                List<DrugTender> rawTenders = drugTenderService.GetOngoingTenders();
                foreach (DrugTender rawTender in rawTenders)
                {
                    AddOneTender(rawTender, retVal);
                }

                return Ok(retVal);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
        [HttpPost("availability")]
        public IActionResult CheckAvailability(TenderOffer tenderInfo)
        {
            List<TenderInfo> infoList = new List<TenderInfo>();
            medicineService = new MedicineService(dbContext);
            return Ok(medicineService.CheckForDrugsAvailability(TenderInfoToList(tenderInfo.TenderOfferInfo)));
        }

            [HttpGet("finished")] // Get /api/tenderOffer/ongoing
        public IActionResult GetFinished()
        {
            drugTenderService = new DrugTenderService(dbContext);
            List<TenderOfferDto> retVal = new List<TenderOfferDto>();
            try
            {
                List<TenderOffer> rawTenders = drugTenderService.GetFinshedTenderOffers();
                foreach (TenderOffer rawTender in rawTenders)
                {
                    AddOneTenderOffer(rawTender, drugTenderService.getDrugTenderById(rawTender.TenderId), retVal);
                }

                return Ok(retVal);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
        [HttpPost("finish")]
        public IActionResult FinishTender(TenderOfferDto demand)
        {
            medicineService = new MedicineService(dbContext);
            drugTenderService = new DrugTenderService(dbContext);
            var client = new RestClient(this.GetIntegreationLink());
            var request = new RestRequest("/api/drugPurchase/finish", Method.POST);
            Console.WriteLine(demand.Id);


            SetApiKeyInHeader(demand, request);

            SetRequestBody(demand, request);

            IRestResponse response = client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<DrugTenderDto> retInfo = this.getDrugToSell(this.DemandToString(demand.TenderInfo));
                foreach(DrugTenderDto d in retInfo)
                {
                    medicineService.SellDrugUrgent(d.DrugName, d.Amount);   
                }

                TenderOffer offerk = drugTenderService.getTenderOfferById(demand.Id);
                List<TenderOffer> offers = drugTenderService.GetOffersForTender(offerk.TenderId);


                foreach (TenderOffer offer in offers)
                {
                    drugTenderService.RemoveOffer(offer.Id);
                }
                return Ok();
                
            }
            else
            return Unauthorized(false);
        }
        private string DemandToString(List<DrugTenderDto> list)
        {
            string ret = "";
            foreach(DrugTenderDto dto in list)
            {
                ret += dto.DrugName + " - " + dto.Amount + " , ";
            }
            return ret.Remove(ret.Length - 2, 2);
        }

        private List<DrugTenderDto> getDrugToSell(string info)
        {
            string[] infos = info.Split(",");
            List<DrugTenderDto> retInfo = new List<DrugTenderDto>();
            foreach (string s in infos)
            {
                string[] singleDrugInfo = s.Split("-");
                DrugTenderDto drug = new DrugTenderDto(singleDrugInfo[0].Trim(), int.Parse(singleDrugInfo[1].Trim()));
                retInfo.Add(drug);
            }
            return retInfo;
        }


    private static void AddOneTender(DrugTender rawTender, List<TenderDto> retVal)
        {
           
            TenderDto oneTender = new TenderDto(rawTender.Id, rawTender.TenderEnd);
            foreach (string drugWithPrice in rawTender.TenderInfo.Split(","))
            {
                AddOneDrug(drugWithPrice, oneTender);
            }

            retVal.Add(oneTender);
        }
        private static void AddOneTenderOffer(TenderOffer rawTender, DrugTender tender, List<TenderOfferDto> retVal)
        {
            TenderOfferDto oneTender = new TenderOfferDto(rawTender.Id, tender.TenderEnd, rawTender.IsAccepted);
            foreach (string drugWithPrice in rawTender.TenderOfferInfo.Split(","))
            {
                AddOneDrugForOffer(drugWithPrice, oneTender);
            }

            retVal.Add(oneTender);
        }

        private static void AddOneDrug(string drugWithPrice, TenderDto oneTender)
        {
            string[] info = drugWithPrice.Split(" - ");
            oneTender.TenderInfo.Add(new DrugTenderDto(info[0], Int32.Parse(info[1])));
        }
        private static void AddOneDrugForOffer(string drugWithPrice, TenderOfferDto oneTender)
        {
            string[] info = drugWithPrice.Split(" - ");
            oneTender.TenderInfo.Add(new DrugTenderDto(info[0], Int32.Parse(info[1])));
        }

        private static TenderInfo StringToTenderInfo(string drugWithPrice)
        {
            
            string[] info = drugWithPrice.Split("-");
            return new TenderInfo(info[0].Trim(), Int32.Parse(info[1]));
        }

        private static List<TenderInfo> TenderInfoToList(string tenderInfo)
        {
            List<TenderInfo> ret = new List<TenderInfo>();
            foreach (string drugWithPrice in tenderInfo.Split(","))
            {
                if(!SkipDrug(drugWithPrice))
                ret.Add(StringToTenderInfo(drugWithPrice));
            }
            return ret;
        }
        private static bool SkipDrug(string info)
        {
            string[] split = info.Split("-");
            return Int32.Parse(split[1]) <= 0;
        }
        
        private string GetIntegreationLink()
        {
            string domain = Environment.GetEnvironmentVariable("HOSPITAL_DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("HOSPITAL_PORT") ?? "5000";
            string domport = $"http://{domain}:{port}";

            return domport;
        }
        private static void SetRequestBody(TenderOfferDto demand, RestRequest request)
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



    private void SetApiKeyInHeader(TenderOfferDto demand, RestRequest request)
    {
        string ApiKey = "";
        foreach (var df in dbContext.Hospitals.ToList())
        {
            if (df.Url.Equals(this.GetIntegreationLink()))
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
