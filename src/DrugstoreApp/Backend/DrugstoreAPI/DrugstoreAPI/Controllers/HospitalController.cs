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
using DrugstoreAPI.Repository;
using Integration.Repository.Sql;
using Drugstore.Models;
using Service;
using DrugstoreAPI.Models;
using DrugstoreAPI.Dtos;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")] // /api/DrugstoreFeedbackWithAPI
    [ApiController]

    public class HospitalController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public HospitalService hospitalService = new HospitalService();


        public HospitalController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpPost]
        public IActionResult Post(HospitalDto hospital)
        {
            hospitalService = new HospitalService(dbContext);
            Hospital newHospital = new Hospital(hospital.HospitalName,hospital.URLAddress, hospital.ApiKey);
            HospitalSqlRepository repo = new HospitalSqlRepository();
            repo.dbContext = dbContext;
            repo.Save(newHospital);
            return Ok();
        }

    }
}
