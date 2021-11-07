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
        public DrugstoreFeedbackSqlRepository repoFeedback = new DrugstoreFeedbackSqlRepository();
        public DrugstoreSqlRepository repoDrugstores = new DrugstoreSqlRepository();
        //public DrugstoreFeedbackService FeedbackService = new DrugstoreFeedbackService();


        public DrugstoreResponseController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpPost]
        public IActionResult ReceiveResponse(PharmacyResponseDto pharmacyResponse)
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
