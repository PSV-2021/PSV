using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
//using Integration.Model;
using Model.DataBaseContext;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public DrugstoreController(MyDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]       // GET /api/product
        public IActionResult Get()
        {
            List<Integration.Model.Drugstore> result = new List<Integration.Model.Drugstore>();
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));
            return Ok(result);
        }
    }
}
