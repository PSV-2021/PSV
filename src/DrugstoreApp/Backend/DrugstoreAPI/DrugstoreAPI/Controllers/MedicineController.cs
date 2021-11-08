using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugstoreAPI.Adapters;
using DrugstoreAPI.Dtos;

using Drugstore.Models;
using Drugstore.Repository.Sql;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public MedicineSqlRepository repo = new MedicineSqlRepository();

        public MedicineController(MyDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            repo.DbContext = this.dbContext;
            return Ok(repo.GetAll());
        }

        [HttpGet("{id?}")]
        public IActionResult Get(long id)
        {
            Medicine medicine = dbContext.Medicines.FirstOrDefault(medicine => medicine.Id == id);

            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MedicineAdapter.MedicineToMedicineDto(medicine));
            }
        }

        [HttpPost]
        public IActionResult Add(MedicineDto dto)
        {
            if (dto.Name.Length <= 0 || dto.Price <= 0)
            {
                return BadRequest();
            }
            int id = dbContext.Medicines.ToList().Count > 0 ? dbContext.Medicines.ToList().Max(medicine => medicine.Id) + 1 : 1;
            Medicine medicine = MedicineAdapter.MedicineDtoToMedicine(dto);
            medicine.Id = id;
            dbContext.Medicines.Add(medicine);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(long id = 0)
        {
            Medicine medicine = dbContext.Medicines.ToList().Find(medicine => medicine.Id == id);

            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Medicines.Remove(medicine);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}