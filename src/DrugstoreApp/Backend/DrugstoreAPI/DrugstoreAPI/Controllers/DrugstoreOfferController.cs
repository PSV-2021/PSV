using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Service;
using Drugstore.Repository.Interfaces;
using Service;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using Drugstore.Service;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreOfferController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public DrugstoreOfferService drugstoreOfferService;

        public DrugstoreOfferController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpPost]
        public IActionResult Post(DrugstoreOfferDto offer)
        {
            drugstoreOfferService = new DrugstoreOfferService(dbContext);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var body = new
                {
                    Id = drugstoreOfferService.GetNewRadnomId(),
                    Title = offer.Title,
                    Content = offer.Content,
                    DrugstoreName = "Apoteka 1",
                    StartDate = offer.StartDate,
                    EndDate = offer.EndDate

                };
                DrugstoreOffer drugstoreOffer = new DrugstoreOffer(body.Id, body.Content, body.Title, body.StartDate, body.EndDate, body.DrugstoreName);
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                var bodyNew = Encoding.UTF8.GetBytes(jsonBody);
                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: bodyNew);
                drugstoreOfferService.SaveOffer(drugstoreOffer);
               
                return Ok(true);
               

            }
        }
        public string GetNewRadnomId()
        {
            return Guid.NewGuid().ToString();
        }


    }
}
