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
    public class DrugstoreFeedbackController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreService drugstoreService = new DrugstoreService();
        public DrugstoreFeedbackService drugstoreFeedbackService = new DrugstoreFeedbackService();
        public DrugstoreFeedbackSqlRepository repoFeedback = new DrugstoreFeedbackSqlRepository();
        public DrugstoreSqlRepository repoDrugstores = new DrugstoreSqlRepository();

        public DrugstoreFeedbackController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            drugstoreFeedbackService = new DrugstoreFeedbackService(dbContext);
            drugstoreService = new DrugstoreService(new DrugstoreSqlRepository(dbContext));
        }

        [HttpGet]   // GET /api/drugstorefeedback
        public IActionResult Get()
        {
            try
            {
                var result = drugstoreFeedbackService.GetAll().Join(repoDrugstores.GetAll(), f => f.DrugstoreId,
                    d => d.Id,
                    (df, d) =>
                        new
                        {
                            Id = df.Id,
                            DrugstoreName = d.Name,
                            Content = df.Content,
                            Response = df.Response
                        });

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }
        
        [HttpPost] // POST /api/drugstorefeedback
        public IActionResult Post(NewPharmacyReviewDto pharmacyReview)
        {
            try
            {
                string randomId = new DrugstoreFeedbackService(dbContext).GetNewRadnomId();
                var client = new RestClient(drugstoreService.GetDrugStoreURL(pharmacyReview.pharmacyId, dbContext));
                var request = new RestRequest("/api/drugstoreresponse", Method.POST);

                string apiKey = FindApiKey(pharmacyReview);

                if (apiKey.Equals(""))
                    return BadRequest("This action is not posible");

                request.AddHeader("ApiKey", apiKey);
                request.AddHeader("Content-Type", "application/json");

                var body = new
                {
                    Id = randomId,
                    HospitalName = "Health",
                    Content = pharmacyReview.review,
                    Response = ""
                };

                request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(body));

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    repoFeedback.dbContext = dbContext;
                    DrugstoreFeedback dfb = new DrugstoreFeedback(randomId, pharmacyReview.pharmacyId,
                        pharmacyReview.review, "",
                        DateTime.Now, DateTime.MinValue);
                    drugstoreFeedbackService.SaveNewFeedback(dfb);

                    return Ok(response.Content);
                }
                return Unauthorized("You are not authorized for this action.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }

        }

        private string FindApiKey(NewPharmacyReviewDto pharmacyReview)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Id.Equals(pharmacyReview.pharmacyId))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            return ApiKey;
        }
    }
}
