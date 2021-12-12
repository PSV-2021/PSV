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
using DrugstoreAPI.Service;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        public MedicineService medicineService;

        public MedicineController(MyDbContext context)
        {
            this.medicineService = new MedicineService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(medicineService.GetAll());
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Medicine medicine = medicineService.GetOne(id);
            if (medicine == null) return NotFound();
            else return Ok(MedicineAdapter.MedicineToMedicineDto(medicine));
        }

        [HttpPost]
        public IActionResult Add(MedicineDto dto)
        {
            if (dto.Name.Length <= 0 || dto.Price <= 0) return BadRequest();
            Medicine medicine = MedicineAdapter.MedicineDtoToMedicine(dto);
            medicineService.Add(medicine);
            return Ok();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(int id)
        {
            if (!medicineService.Delete(id)) return NotFound();
            else return Ok();
        }

        public IActionResult Filter([FromQuery] string name, [FromQuery] string substance)
        {
            IEnumerable<string> headerValues = Request.Headers["ApiKey"];
            var key = headerValues.FirstOrDefault();
            if (key == null || !key.Equals("abcde"))
                return Unauthorized();
            CheckFilterParameters(ref name, ref substance);
            List<Medicine> result = medicineService.SearchMedicineByNameAndSubstance(name, substance);
            return Ok(result);
        }

        private static void CheckFilterParameters(ref string name, ref string substance)
        {
            if (name == null)
                name = "";
            if (substance == null)
                substance = "";
        }
    }
}