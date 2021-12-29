using Drugstore.Models;
using Drugstore.Service;
using DrugstoreAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
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
        public TenderOfferController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
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
                TenderOffer tenderOffer = new TenderOffer(offer.Id,offer.TenderOfferInfo,offer.Price,offer.TenderId,offer.IsAccepted,offer.DrugstoreId,offer.IsActive);
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

        private static void AddOneTender(DrugTender rawTender, List<TenderDto> retVal)
        {
            TenderDto oneTender = new TenderDto(rawTender.Id, rawTender.TenderEnd);
            foreach (string drugWithPrice in rawTender.TenderInfo.Split(","))
            {
                AddOneDrug(drugWithPrice, oneTender);
            }

            retVal.Add(oneTender);
        }

        private static void AddOneDrug(string drugWithPrice, TenderDto oneTender)
        {
            string[] info = drugWithPrice.Split(" - ");
            oneTender.TenderInfo.Add(new DrugTenderDto(info[0], Int32.Parse(info[1])));
        }

    }
}
