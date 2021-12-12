using Microsoft.AspNetCore.Mvc;
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Service;
using Drugstore.Service;
using Service;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugSpecificationController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public HospitalService HospitalService;
        public DrugSpecificationService drugSpecificationService;

        public DrugSpecificationController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.HospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
            drugSpecificationService = new DrugSpecificationService(dbContext);
        }

        [HttpPost]
        public IActionResult Post(DrugSpecificationDto drugSpec)
        {
            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                drugSpec.Name = FormatString(drugSpec.Name);
                var headers = Request.Headers["ApiKey"];
                foreach (string header in headers)
                {
                    if (HospitalService.CheckApiKey(header))
                    {
                        string specificationContent = drugSpecificationService.ReadDrugSpecification(drugSpec.Name);
                        if (!specificationContent.Equals(""))
                        {
                            drugSpecificationService.SaveDrugSpecification(drugSpec.Name, specificationContent);
                            drugSpecificationService.UploadDrugSpecification(drugSpec.Name);
                            return Ok();
                        }
                        else
                            return NoContent();
                    }
                }
            }
            return Unauthorized();
        }

        private string FormatString(string drugName)
        {
            if (drugName != "")
            {
                drugName = drugName.Trim();
                drugName = char.ToUpper(drugName[0]) + drugName.Substring(1).ToLower();
            }
                return drugName;
        }

    }
}
