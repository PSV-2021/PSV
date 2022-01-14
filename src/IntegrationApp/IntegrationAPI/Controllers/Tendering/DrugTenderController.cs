using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Integration.Repository.Sql;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Service;
using Integration.Tendering.Model;
using Integration.Model;
using RabbitMQ.Client;
using System.Text;
using Integration.Model;
using Integration.Tendering.Service;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugTenderController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugTenderService DrugTenderService;
        public DrugstoreService DrugstoreService;
        public MailService MailService;
        private string host = Environment.GetEnvironmentVariable("RABBIT_HOST") ?? "localhost";


        public DrugTenderController(MyDbContext db)
        {
            this.dbContext = db;
            DrugTenderService = new DrugTenderService(db);
            DrugstoreService = new DrugstoreService(new DrugstoreSqlRepository(dbContext));
            MailService = new MailService(db);

        }

        [HttpPost] // POST /api/drugTender
        public IActionResult Post(TenderDto tender)
        {
            var factory = new ConnectionFactory() { HostName = host };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
                string tenderId = DrugTenderService.GenId();
                DrugTender drugstoreTender = new DrugTender(tenderId, tender.TenderEnd.AddDays(1).AddMinutes(59).AddSeconds(59), FormatTenderInfo(tender.TenderInfo), false);
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(drugstoreTender);
                var bodyNew = Encoding.UTF8.GetBytes(jsonBody);
                channel.BasicPublish(exchange: "tender",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: bodyNew);
                DrugTenderService.Save(drugstoreTender);

                return Ok(true);
            }
        }

        [HttpPost("complete")] // POST /api/drugTender
        public IActionResult PostGas(TenderFinisherDTO tenderFinisherDto)
        {
            var factory = new ConnectionFactory() { HostName = host };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tenderFinish", type: ExchangeType.Direct);
                
                foreach(Drugstore d in DrugstoreService.GetAll())
                {
                    TenderOffer tenderOfferNew = DrugTenderService.getTenderOfferById(tenderFinisherDto.tenderId);
                    DrugTender drugTender = DrugTenderService.getDrugTenderById(tenderOfferNew.TenderId);
                    List<TenderOffer> offers = DrugTenderService.GetOffersForTender(tenderOfferNew.TenderId);
                    bool exist = false;
                    foreach (TenderOffer offer in offers)
                    {
                        if (offer.DrugstoreId == d.Id)
                            exist = true;
                    }
                    if(!exist)
                        continue;

                    if (tenderFinisherDto.drugstoreName == d.Name)
                    {
                        string tenderWin = "Winner:" + tenderFinisherDto.tenderId;
                        string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(tenderWin);
                        var bodyNew = Encoding.UTF8.GetBytes(jsonBody);
                        channel.BasicPublish(exchange: "tenderFinish",
                                             routingKey: tenderFinisherDto.drugstoreName,
                                             basicProperties: null,
                                             body: bodyNew);
                     TenderOffer tenderOffer  =  DrugTenderService.getTenderOfferById(tenderFinisherDto.tenderId);
                        tenderOffer.IsAccepted = true;
                        tenderOffer.IsActive = false;
                        DrugTenderService.UpdateTenderOffer(tenderOffer);
                        drugTender.isFinished = true;
                        Console.WriteLine(drugTender.isFinished);
                        DrugTenderService.UpdateDrugTender(drugTender);
                        MailService.SendEmailForTenderWin(d, tenderOfferNew);
                    }
                    else
                    {
                        string tenderLose = "Loser:" + tenderFinisherDto.tenderId;

                        string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(tenderLose);
                        var bodyNew = Encoding.UTF8.GetBytes(jsonBody);
                        channel.BasicPublish(exchange: "tenderFinish",
                                             routingKey: "loser",
                                             basicProperties: null,
                                             body: bodyNew);
                        TenderOffer tenderOffer = DrugTenderService.getTenderOfferById(tenderFinisherDto.tenderId);
                        tenderOffer.IsAccepted = false;
                        tenderOffer.IsActive = false;
                        DrugTenderService.UpdateTenderOffer(tenderOffer);
                        drugTender.isFinished = true;
                        Console.WriteLine(drugTender.isFinished);
                        DrugTenderService.UpdateDrugTender(drugTender);
                        MailService.SendEmailForTenderLoser(d, tenderOffer);

                    }
                }
                return Ok(true);

            }
        }

        [HttpGet("ongoing")] // Get /api/drugTender/ongoing
        public IActionResult GetOnGoing()
        {
            List<TenderDto> retVal = new List<TenderDto>();
            try
            {
                List<DrugTender> rawTenders = DrugTenderService.GetOngoingTenders();
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


        [HttpGet] // Get /api/drugTender/offer/2
        [Route("offer/{Id?}")]
        public IActionResult GetAllOffersForTender(string Id)
        {
            List<TenderOfferDto> retVal = new List<TenderOfferDto>();
            try
            {
                List<TenderOffer> rawOffers = DrugTenderService.GetOffersForTender(Id);
                foreach (TenderOffer rawOffer in rawOffers)
                {
                    FillDrugList(rawOffer.DrugstoreId, rawOffer, retVal);
                }
                return Ok(retVal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        [HttpGet] // Get /api/drugTender/offer/2
        [Route("offers/{id?}")]
        public IActionResult GetAllOffersForDrugstore(int id)
        {
            List<TenderOfferDto> retVal = new List<TenderOfferDto>();
            try
            {
                List<TenderOffer> rawOffers = DrugTenderService.GetOffersForDrugstoreActive(id);
                foreach (TenderOffer rawOffer in rawOffers)
                {
                    FillDrugList(id, rawOffer, retVal);
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

        private void FillDrugList(int id, TenderOffer rawOffer, List<TenderOfferDto> retVal)
        {
            List<DrugTenderDto> listOfDrugs = new List<DrugTenderDto>();
            foreach (string drugWithAmount in rawOffer.TenderOfferInfo.Split(","))
            {
                AddDrugToList(drugWithAmount, listOfDrugs);
            }

            retVal.Add(new TenderOfferDto(DrugstoreService.GetDrugstoreById(id).Name, listOfDrugs, rawOffer.Price,rawOffer.Id));
        }

        private static void AddDrugToList(string drugWithAmount, List<DrugTenderDto> listOfDrugs)
        {
            string[] info = drugWithAmount.Split(" - ");
            DrugTenderDto oneDrug = new DrugTenderDto(info[0], Int32.Parse(info[1]));
            listOfDrugs.Add(oneDrug);
        }

        private string FormatTenderInfo(List<DrugTenderDto> info) {
            string retString = "";
            foreach (DrugTenderDto dt in info) {
                retString += dt.DrugName + " - " + dt.Amount + ", ";
            }
            return retString.Substring(0, retString.Length - 2);
        }

        [HttpPost("chartsInfo")] // POST /api/drugTender
        public IActionResult GetCharts(DateRange range)
        {
            Console.WriteLine(range.From.AddHours(1));
            Console.WriteLine(range.To.AddHours(1));
            return Ok(DrugTenderService.GetDrugstoreTenderInfo(range.ConvertDateFromAngular()));
        }

        [HttpPost("chartInfo")] // POST /api/drugTender
        public IActionResult GetSingleChart(DateRangeAndIdDTO rangeAndId)
        {
            Console.WriteLine(rangeAndId.From.AddHours(1));
            Console.WriteLine(rangeAndId.To.AddHours(1));
            DateRange range = new DateRange(rangeAndId.From, rangeAndId.To);
            return Ok(DrugTenderService.GetSingleDrugstoreTenderInfo(range.ConvertDateFromAngular(), rangeAndId.Id));
        }
    }
}
