using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using Integration_API.DTOs;
using Integration.Model;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreResponseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreFeedbackSqlRepository repoFeedback = new DrugstoreFeedbackSqlRepository();
        public DrugstoreSqlRepository repoDrugstores = new DrugstoreSqlRepository();
        //public DrugstoreFeedbackService FeedbackService = new DrugstoreFeedbackService();


        public DrugstoreResponseController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        //[HttpPost]
        //public IActionResult ReceiveResponse(PharmacyResponseDto pharmacyResponse)
        //{   

        //    repoFeedback.dbContext = dbContext;
        //    Integration.Model.DrugstoreFeedback forEdit = repoFeedback.GetById(pharmacyResponse.Id);
        //    forEdit.Response = pharmacyResponse.Response;
        //    //Integration.Model.DrugstoreFeedback fdbEdit = new Integration.Model.DrugstoreFeedback(forEdit.Id, forEdit.DrugstoreId,forEdit.Content, forEdit.Response, forEdit.SentTime, forEdit.RecievedTime);
            
        //    repoFeedback.Update(forEdit);

        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Post(PharmacyResponseDto pharmacyResponse)
        {


            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                // Can now check if the value is true:
                var value = Request.Headers["ApiKey"];
                foreach (string nesto in value)
                {
                    if (this.checkApiKey(nesto, dbContext))
                    {
                        repoFeedback.dbContext = dbContext;
                        Integration.Model.DrugstoreFeedback forEdit = repoFeedback.GetById(pharmacyResponse.Id);
                        forEdit.Response = pharmacyResponse.Response;
                        //Integration.Model.DrugstoreFeedback fdbEdit = new Integration.Model.DrugstoreFeedback(forEdit.Id, forEdit.DrugstoreId,forEdit.Content, forEdit.Response, forEdit.SentTime, forEdit.RecievedTime);

                        repoFeedback.Update(forEdit);

                        return Ok();
                    }
                }

            }
            return Unauthorized();

        }

        public bool checkApiKey(string apiKey, MyDbContext dbContext)
        {
            bool found = false;
            foreach (Drugstore h in dbContext.Drugstores.ToList())
            {
                if (h.ApiKey.Equals(apiKey))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }




    }
}
