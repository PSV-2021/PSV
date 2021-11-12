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
using Integration.Service;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreResponseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreFeedbackSqlRepository repoFeedback = new DrugstoreFeedbackSqlRepository();
        public DrugstoreSqlRepository repoDrugstores = new DrugstoreSqlRepository();
        public DrugstoreFeedbackService drugstoreFeedbackService = new DrugstoreFeedbackService();

        public DrugstoreResponseController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

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
                    if (drugstoreFeedbackService.checkApiKey(nesto, dbContext))
                    {
                        repoFeedback.dbContext = dbContext;
                        Integration.Model.DrugstoreFeedback forEdit = repoFeedback.GetById(pharmacyResponse.Id);
                        forEdit.Response = pharmacyResponse.Response;
                        repoFeedback.Update(forEdit);

                        return Ok();
                    }
                }

            }
            return Unauthorized();

        }

    }
}
