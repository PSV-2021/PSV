using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Medicines.Model;
using Hospital.Medicines.Service;
using Hospital.Medicines.Repository.Sql;
using Hospital.SharedModel;
using HospitalAPI.DTOs;
using RestSharp;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugPurchaseController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugService medicineService;

        public DrugPurchaseController(MyDbContext db)
        {
            this.medicineService = new DrugService(db);
            dbContext = db;
        }


        [HttpPut("urgent")]
        public IActionResult UrgentPurchase(DrugAmountDemandDto demand)
        {
            medicineService.AddDrugUrgent(demand.Name, demand.Amount);
            return Ok(true);                         
        }
        //COKA
    }
}
