using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;

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
        public IActionResult Respond(String response)
        {

            //List<DrugstoreFeedback> result = new List<DrugstoreFeedback>();
            //repo.GetAll().ForEach(feedback => result.Add(new DrugstoreFeedback(feedback.Id, feedback.DrugstoreToken, feedback.Content,
            //    feedback.Response, feedback.SentTime, feedback.SentTime)));
            /*
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            */
            Console.WriteLine("Status: " + response);
            return Ok();
        }
        



    }
}
