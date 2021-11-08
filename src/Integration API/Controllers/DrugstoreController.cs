using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Repository.Sql;

using Integration.Model;
using Model.DataBaseContext;
using Integration_API.DTOs;

using Integration.Service;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreSqlRepository repo = new DrugstoreSqlRepository();
        public DrugstoreService drugstoreService = new DrugstoreService();

        
        public DrugstoreController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpGet]       // GET /api/drugstore
        public IActionResult Get()
        {
            repo.dbContext = dbContext;
            List<Drugstore> result = new List<Drugstore>();
            repo.GetAll().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url, drugstore.ApiKey, drugstore.Email, drugstore.Address)));

            return Ok(result);
        }

        [HttpGet("/name/{id}")] // GET /api/test2/int/3
        public IActionResult GetDrugstoreName(int id)
        {
            repo.dbContext = dbContext;
            string result = repo.GetDrugstoreName(id);
            return Ok(result);
        }

        [HttpPost] // POST /api/drugstore/newdrugstore
        public IActionResult Post(RegistrationDto newPharmacy)
        {
            repo.dbContext = dbContext;
            int maxId = repo.GetMaxId();
            Drugstore ds = new Drugstore(++maxId, newPharmacy.DrugstoreName, newPharmacy.URLAddress, Guid.NewGuid().ToString(), newPharmacy.Email, newPharmacy.Address);
            dbContext.Drugstores.Add(ds);
            dbContext.SaveChanges();
            return Ok(ds);
        }
    }
}
