using Drugstore.Models;
using Drugstore.Service;
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

    }
}
