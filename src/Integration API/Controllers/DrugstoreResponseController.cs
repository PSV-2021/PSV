using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using Integration_API.DTOs;
using Integration_API.Model;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreResponseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreFeedbackSqlRepository repo = new DrugstoreFeedbackSqlRepository();

        public DrugstoreResponseController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpPost]   // POST /api/drugstoreresponse
        public IActionResult Respond(PharmacyResponseDto response)
        {

            //List<DrugstoreFeedback> result = new List<DrugstoreFeedback>();
            //repo.GetAll().ForEach(feedback => result.Add(new DrugstoreFeedback(feedback.Id, feedback.DrugstoreToken, feedback.Content,
            //    feedback.Response, feedback.SentTime, feedback.SentTime)));
            /*
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            */
            DrugstoreResponse dres = new DrugstoreResponse(1, 1111, response.Response, DateTime.Now, DateTime.Now);
            Console.WriteLine("Status: " + response.Response);
            return Ok(dres);
        }
        



    }
}
