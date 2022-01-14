using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using DrugstoreAPI.Filters;
using RestSharp;
using Drugstore.Models;
using Service;
using DrugstoreAPI.Models;
using DrugstoreAPI.Dtos;
using Drugstore.Repository.Sql;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")] // /api/DrugstoreFeedbackWithAPI
    [ApiController]

    public class HospitalController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public HospitalService hospitalService;


        public HospitalController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            hospitalService = new HospitalService(new HospitalSqlRepository(db));
        }

        [HttpPost]
        public IActionResult Post(HospitalDto hospital)
        {
            Hospital newHospital = new Hospital(hospital.HospitalName,hospital.URLAddress, hospital.ApiKey, "nabavite sta fronta!");
            hospitalService.SaveNewHospital(newHospital);
            return Ok();
        }

    }
}
