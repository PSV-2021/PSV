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
    public class DrugstoreFeedbackController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreFeedbackSqlRepository repo = new DrugstoreFeedbackSqlRepository();

        public DrugstoreFeedbackController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpGet]   // GET /api/drugstorefeedback
        public IActionResult Get()
        {
            repo.dbContext = dbContext;
            List<DrugstoreFeedback> result = new List<DrugstoreFeedback>();
            repo.GetAll().ForEach(feedback => result.Add(new DrugstoreFeedback(feedback.Id, feedback.DrugstoreToken, feedback.Content,
                feedback.Response, feedback.SentTime, feedback.SentTime)));
            /*
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            */
            return Ok(result);
        }



    }
}
