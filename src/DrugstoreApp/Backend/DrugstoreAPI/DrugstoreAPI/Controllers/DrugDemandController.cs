using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Service;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugDemandController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public MedicineService medicineService;

        public DrugDemandController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
        }

        [HttpPost]
        public IActionResult Post(DrugAmountDemandDto demand)
        {
            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                var headers = Request.Headers["ApiKey"];
                foreach (string header in headers)
                {
                    if (this.CheckApiKey(header))
                    {
                       return Ok(medicineService.CheckForAmountOfDrug(demand.Name, demand.Amount));
                    }
                }
            }
            return Unauthorized();
        }


        private bool CheckApiKey(string apiKey)
        {
            bool found = false;
            foreach (Hospital h in dbContext.Hospitals.ToList())
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
