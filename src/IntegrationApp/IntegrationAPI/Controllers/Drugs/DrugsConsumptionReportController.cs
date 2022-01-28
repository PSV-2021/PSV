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
using Integration.Notifications.Model;
using Microsoft.AspNetCore.Cors;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsConsumptionReportController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugsConsumptionReportService drugsConsumptionService;
        public DrugstoreService drugstoreService;

        public DrugsConsumptionReportController(MyDbContext db)
        {
            this.dbContext = db;
            drugsConsumptionService = new DrugsConsumptionReportService(db);
            drugstoreService = new DrugstoreService(new DrugstoreSqlRepository(dbContext));
        }

        [EnableCors("MyPolicy")]
        [HttpPost] // POST /api/DrugsConsumptionReportController
        public IActionResult Post(DateRange range)
        {
            try
            {
                if (drugsConsumptionService.SaveDrugsConsumptionReport(range.ConvertDateFromAngular()))
                {
                   SendNotification(range);
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }

        public IActionResult SendNotification(DateRange range)
        {
            try
            {
                var client = new RestClient(drugstoreService.GetDrugStoreURL(1, dbContext));
                var request = new RestRequest("/api/notification/recieve", Method.POST); //promeni posle

                string apiKey = FindApiKey(1);

                if (apiKey.Equals(""))
                    return BadRequest("This action is not posible");

                request.AddHeader("ApiKey", apiKey);
                request.AddHeader("Content-Type", "application/json");

                var body = new
                {
                    HospitalName = "Health",
                    Posted = DateTime.Now,
                    Title = "Obavestenje o pristizanju novog fajla",
                    Content = "Stigao je novi fajl od bolnice Health - Izvestaj o potrosnji lekova - " + range.ConvertDateFromAngular().FormatDate(),
                    IsRead = false,
                };

                request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(body));

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok(response.Content);
                }
                return Unauthorized("You are not authorized for this action.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }

        }

        private string FindApiKey(int id)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Id.Equals(id))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            return ApiKey;
        }
    }
}
