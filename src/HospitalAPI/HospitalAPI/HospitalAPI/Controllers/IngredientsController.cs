using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
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
        public IngredientService ingredientService;

        public IngredientsController(MyDbContext context)
        {
            this.context = context;
            ingredientService = new IngredientService(new IngredientSqlRepository(context));
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Ingridient> result = new List<Ingridient>();
            result = ingredientService.GetAllIngredients();

            return Ok(result);
        }
    }
}
