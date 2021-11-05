using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugstoreAPI.Adapters;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Models;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<string> lista = new List<string>();
            lista.Add("VOLIM");
            // List<MedicineDto> result = new List<MedicineDto>();
            // Program.MedicineList.ForEach(medicine => result.Add(MedicineAdapter.MedicineToMedicineDto(medicine)));
            Console.WriteLine("Status:Najjaci");
            return Ok(lista);
        }

        [HttpGet("{id?}")]
        public IActionResult Get(long id)
        {
            Medicine medicine = Program.MedicineList.Find(medicine => medicine.Id == id);
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

            long id = Program.MedicineList.Count > 0 ? Program.MedicineList.Max(medicine => medicine.Id) + 1 : 1;
            Medicine medicine = MedicineAdapter.MedicineDtoToMedicine(dto);
            medicine.Id = id;
            Program.MedicineList.Add(medicine);
            return Ok();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(long id = 0)
        {
            Medicine medicine = Program.MedicineList.Find(medicine => medicine.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                Program.MedicineList.Remove(medicine);
                return Ok();
            }
        }
    }
}