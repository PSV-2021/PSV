using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Repository.Sql;
using Integration.Service;
using Integration.Model;
using DrugstoreFeedback = Integration.Model.DrugstoreFeedback;
using System.Text.Json;
using System.Net.NetworkInformation;
using RestSharp;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsConsumptionReportController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugsConsumptionReportService drugsConsumptionService;

        public DrugsConsumptionReportController(MyDbContext db)
        {
            this.dbContext = db;
            drugsConsumptionService = new DrugsConsumptionReportService(db);
        }
        
        [HttpPost] // POST /api/DrugsConsumptionReportController
        public IActionResult Post(DateRange range)
        {
            try
            {
                drugsConsumptionService.SaveDrugsConsumptionReport(range.ConvertDateFromAngular());
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }
    }
}
