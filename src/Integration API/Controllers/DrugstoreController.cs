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
    public class DrugstoreController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreSqlRepository DrugstoreRepo = new DrugstoreSqlRepository();
        
        public DrugstoreController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpGet]       // GET /api/drugstore
        public IActionResult Get()
        {
            DrugstoreRepo.dbContext = dbContext;
            List<Drugstore> result = new List<Drugstore>();
            DrugstoreRepo.GetAll().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url, drugstore.ApiKey, drugstore.Email, drugstore.Address)));
            return Ok(result);
        }

        [HttpGet("/name/{id}")] // GET /api/test2/int/3
        public IActionResult GetDrugstoreName(int id)
        {
            DrugstoreRepo.dbContext = dbContext;
            string result = DrugstoreRepo.GetDrugstoreName(id);
            /*
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            */
            return Ok(result);
        }

        [HttpPost] // POST /api/drugstore/newdrugstore
        public IActionResult Post(RegistrationDto newPharmacy)
        {
            DrugstoreRepo.dbContext = dbContext;
            int maxId = new DrugstoreService(dbContext).GetMaxId();
            Drugstore ds = new Drugstore(++maxId, newPharmacy.DrugstoreName, newPharmacy.URLAddress, Guid.NewGuid().ToString(), newPharmacy.Email, newPharmacy.Address);
            dbContext.Drugstores.Add(ds);
            dbContext.SaveChanges();
            return Ok(ds);
        }
    }
}
