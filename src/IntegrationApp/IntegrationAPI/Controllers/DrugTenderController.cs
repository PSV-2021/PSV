using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public DrugTenderService drugTenderService;

        public DrugTenderController(MyDbContext db)
        {
            this.dbContext = db;
            drugTenderService = new DrugTenderService(db);
        }
        
        [HttpPost] // POST /api/drugTender
        public IActionResult Post(TenderDto tender)
        {
            drugTenderService.Save(new DrugTender(tender.TenderEnd.AddDays(1).AddMinutes(59).AddSeconds(59), FormatTenderInfo(tender.TenderInfo), false));
            return Ok(true);
        }

        [HttpGet("ongoing")] // Get /api/drugTender/ongoing
        public IActionResult GetOnGoing()
        {
            List<TenderDto> retVal = new List<TenderDto>();
            try
            {
                List<DrugTender> rawTenders = drugTenderService.GetOngoingTenders();
                foreach (DrugTender rawTender in rawTenders)
                {
                    TenderDto oneTender = new TenderDto();
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

        private string FormatTenderInfo(List<DrugTenderDto> info) {
            string retString = "";
            foreach (DrugTenderDto dt in info) {
                retString += dt.DrugName + " - " + dt.Amount + ", ";
            }
            return retString.Substring(0, retString.Length - 2);
        }
    }
}
