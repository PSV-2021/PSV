using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Repository.Sql;
//using Integration.Service;
using DrugstoreFeedback = Integration.Model.DrugstoreFeedback;

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

        [HttpGet(template: "testHit")]
        public IActionResult GetHit()
        {
            List<string> lista = new List<string>();
            lista.Add("POGODJENA BOLNICA");
            // List<MedicineDto> result = new List<MedicineDto>();
            // Program.MedicineList.ForEach(medicine => result.Add(MedicineAdapter.MedicineToMedicineDto(medicine)));
            Console.WriteLine("Status:Najjaci");
            return Ok(lista);
        }

        [HttpGet]   // GET /api/drugstorefeedback
        public IActionResult Get()
        {
            repoFeedback.dbContext = dbContext;
            repoDrugstores.dbContext = dbContext;
            var result = repoFeedback.GetAll().Join(repoDrugstores.GetAll(), f => f.DrugstoreToken, d => d.Id,
                (df, d) =>
                new {
                    Id = df.Id,
                    DrugstoreName = d.Name,
                    Content = df.Content,
                    Response = df.Response
                });

            return Ok(result);
        }
        /*
        [HttpPost] // POST /api/drugstorefeedback
        public IActionResult Post(NewPharmacyReviewDto pharmacyReview)
        {
            repoFeedback.dbContext = dbContext;
            int maxId = new DrugstoreFeedbackService(dbContext).GetMaxId();
            DrugstoreFeedback dfb = new DrugstoreFeedback(++maxId, pharmacyReview.pharmacyId, pharmacyReview.review, "",
                DateTime.Now, DateTime.MinValue);
            dbContext.DrugstoreFeedbacks.Add(dfb);
            dbContext.SaveChanges();
            return Ok(dfb);
        }
        
        */

    }
}
