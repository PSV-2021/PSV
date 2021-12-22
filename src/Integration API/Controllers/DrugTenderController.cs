using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        private string FormatTenderInfo(List<DrugTenderDto> info) {
            string retString = "";
            foreach (DrugTenderDto dt in info) {
                retString += dt.DrugName + " - " + dt.Amount + ", ";
            }
            return retString.Substring(0, retString.Length - 2);
        }
    }
}
