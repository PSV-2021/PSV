using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Repository.Sql;
using Integration_API.Model;
//using Integration.Model;
using Model.DataBaseContext;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreSqlRepository repo = new DrugstoreSqlRepository();
        
        public DrugstoreController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
        }

        [HttpGet]       // GET /api/drugstore
        public IActionResult Get()
        {
            repo.dbContext = dbContext;
            List<Integration_API.Model.Drugstore> result = new List<Integration_API.Model.Drugstore>();
            repo.GetAll().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            return Ok(result);
        }

        [HttpGet("/name/{id}")] // GET /api/test2/int/3
        public IActionResult GetDrugstoreName(string id)
        {
            repo.dbContext = dbContext;
            string result = repo.GetDrugstoreName(id);
            /*
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            */
            return Ok(result);
        }
    }
}
