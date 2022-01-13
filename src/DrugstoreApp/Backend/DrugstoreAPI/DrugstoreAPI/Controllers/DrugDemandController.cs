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
using Drugstore.Repository.Interfaces;
using Service;
using Drugstore.Service;
using RestSharp;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugDemandController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public MedicineService medicineService;
        public HospitalService HospitalService;


        public DrugDemandController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.HospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
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
                    if (HospitalService.CheckApiKey(header))
                    {
                        return Ok(medicineService.CheckForAmountOfDrug(demand.Name, demand.Amount));
                    }
                }
            }
            return Unauthorized();
        }
        [HttpPost("urgent")]
        public IActionResult UrgentPurchase(DrugAmountDemandDto demand)
        {
            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                var headers = Request.Headers["ApiKey"];
                foreach (string header in headers)
                {
                    if (HospitalService.CheckApiKey(header))
                    {
                        if (medicineService.SellDrugUrgent(demand.Name, demand.Amount))
                        {
                            //TODO: Posalji mejl
                            return Ok(true);
                        }
                        return Ok(false);
                    }
                }
            }
            return Unauthorized(false);
        }

        

    }
}




 
