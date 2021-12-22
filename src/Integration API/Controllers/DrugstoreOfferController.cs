using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Model.DataBaseContext;
using Integration_API.Repository.Interfaces;
using Integration.Repository.Sql;
using RabbitMQ.Client.Events;
using Integration.Model;
using Integration_API.DTOs;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreOfferController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }


        public DrugstoreOfferController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.factory = new ConnectionFactory() { HostName = "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }


        [HttpGet]   // GET /api/drugstoreOffer
        public IActionResult Get()
        {
            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(dbContext);
            var result = repo.GetAll();

            return Ok(result);
        }



        [HttpPost("pls")]
        public IActionResult Post(PublishedOfferDto offer)
        {

            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(dbContext);
            
                DrugstoreOffer forEdit = repo.GetOne(offer.OfferId);
            if (forEdit != null)
            {
                Console.WriteLine(offer.OfferId);
                forEdit.IsPublished = true;
                repo.Update(forEdit);
                return Ok();
            }
            else
                return Unauthorized();
        }
    }
}
