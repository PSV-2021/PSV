using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_API.Model;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Repository.Sql;
using Integration.Service;
using Integration.Model;
using DrugstoreFeedback = Integration.Model.DrugstoreFeedback;
using RestSharp;
using System.Text.Json;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreFeedbackController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreFeedbackSqlRepository repoFeedback = new DrugstoreFeedbackSqlRepository();
        public DrugstoreSqlRepository repoDrugstores = new DrugstoreSqlRepository();
        //public DrugstoreFeedbackService FeedbackService = new DrugstoreFeedbackService();


        public DrugstoreFeedbackController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpGet]   // GET /api/drugstorefeedback
        public IActionResult Get()
        {
            repoFeedback.dbContext = dbContext;
            repoDrugstores.dbContext = dbContext;
            var result = repoFeedback.GetAll().Join(repoDrugstores.GetAll(), f => f.DrugstoreId, d => d.Id,
                (df, d) =>
                new {
                    Id = df.Id,
                    DrugstoreName = d.Name,
                    Content = df.Content,
                    Response = df.Response
                });

            return Ok(result);
        }
        
        [HttpPost] // POST /api/drugstorefeedback
        public IActionResult Post(NewPharmacyReviewDto pharmacyReview)
        {
            repoFeedback.dbContext = dbContext;
            string randomId = new DrugstoreFeedbackService(dbContext).GetNewRadnomId();
            DrugstoreFeedback dfb = new DrugstoreFeedback(randomId, pharmacyReview.pharmacyId, pharmacyReview.review, "",
                DateTime.Now, DateTime.MinValue);
            dbContext.DrugstoreFeedbacks.Add(dfb);
            dbContext.SaveChanges();


            var client = new RestClient("http://localhost:5001");
            var request = new RestRequest("/api/drugstoreresponse", Method.POST);

            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Id.Equals(pharmacyReview.pharmacyId))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            request.AddHeader("ApiKey", ApiKey);
            request.AddHeader("Content-Type", "application/json");
            
            var body = new
            {
                Id = randomId,
                HospitalName = "Ime bolnice 222",
                Content = pharmacyReview.review,
                Response = ""
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);

            IRestResponse response = client.Execute(request);

            var content = response.Content; // {"message":" created."}

            return Ok(content);
        }

        //[HttpPost]
        //public IActionResult ReceiveResponse(PharmacyResponseDto pharmacyResponse)
        //{
        //    repoFeedback.dbContext = dbContext;
        //    DrugstoreFeedback forEdit = repoFeedback.GetOne(pharmacyResponse.Id);
        //    forEdit.Response = pharmacyResponse.Response;

        //    repoFeedback.Update(forEdit);

        //    return Ok();
        //}


    }
}
