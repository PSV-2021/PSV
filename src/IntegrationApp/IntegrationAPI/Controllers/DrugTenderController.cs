using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Integration.Repository.Sql;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Service;
using Integration.Tendering.Model;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugTenderController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugTenderService DrugTenderService;
        public DrugstoreService DrugstoreService;


        public DrugTenderController(MyDbContext db)
        {
            this.dbContext = db;
            DrugTenderService = new DrugTenderService(db);
            DrugstoreService = new DrugstoreService(new DrugstoreSqlRepository(dbContext));

        }
        
        [HttpPost] // POST /api/drugTender
        public IActionResult Post(TenderDto tender)
        {
            DrugTenderService.Save(new DrugTender(tender.TenderEnd.AddDays(1).AddMinutes(59).AddSeconds(59), FormatTenderInfo(tender.TenderInfo), false));
            return Ok(true);
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
                    TenderDto oneTender = new TenderDto();
                    oneTender.Id = rawTender.Id;
                    oneTender.TenderEnd = rawTender.TenderEnd;
                    string[] drugsWithPrices = rawTender.TenderInfo.Split(",");
                    foreach (string drugWithPrice in drugsWithPrices)
                    {
                        string[] info = drugWithPrice.Split(" - ");
                        oneTender.TenderInfo.Add(new DrugTenderDto(info[0], Int32.Parse(info[1])));
                    }

                    retVal.Add(oneTender);
                }

                return Ok(retVal);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        [HttpGet] // Get /api/drugTender/ongoing
        [Route("offer/{id?}")]
        public IActionResult GetOnGoing(int id)
        {
            List<TenderOfferDto> retVal = new List<TenderOfferDto>();
            try
            {
                List<TenderOffer> rawOffers = DrugTenderService.GetOffersForTender(id);
                foreach (TenderOffer rawOffer in rawOffers)
                {
                    List<DrugTenderDto> listOfDrugs = new List<DrugTenderDto>();
                    string[] drugsWithAmount = rawOffer.TenderOfferInfo.Split(",");
                    foreach (string drugWithAmount in drugsWithAmount)
                    {
                        string[] info = drugWithAmount.Split(" - ");
                        DrugTenderDto oneDrug = new DrugTenderDto(info[0], Int32.Parse(info[1]));
                        listOfDrugs.Add(oneDrug);
                    }
                    TenderOfferDto oneOffer = new TenderOfferDto(DrugstoreService.GetDrugstoreById(id).Name ,listOfDrugs, rawOffer.Price);
                    retVal.Add(oneOffer);
                }
                return Ok(retVal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        private string FormatTenderInfo(List<DrugTenderDto> info) {
            string retString = "";
            foreach (DrugTenderDto dt in info) {
                retString += dt.DrugName + " - " + dt.Amount + ", ";
            }
            return retString.Substring(0, retString.Length - 2);
        }
    }
}
