using Hospital.Model;
using Hospital.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly MyDbContext context;
        public IngredientSqlRepository ingredientSqlRepository = new IngredientSqlRepository();


        public IngredientsController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            ingredientSqlRepository.context = context;
            List<Ingridient> result = new List<Ingridient>();
            result = ingredientSqlRepository.GetAll();
            return Ok(result);
        }
    }
}
