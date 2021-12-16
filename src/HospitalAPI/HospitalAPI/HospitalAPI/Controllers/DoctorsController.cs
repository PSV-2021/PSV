using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Hospital.SharedModel;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext context;
        public DoctorService doctorService;

        public DoctorsController(MyDbContext context)
        {
            this.context = context;
            doctorService = new DoctorService(new DoctorSqlRepository(context));
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Doctor> result = new List<Doctor>();
            result = doctorService.GetGeneralDoctors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorsBySpecialty(string id)
        {
            int idSpecialty = int.Parse(id);
            Console.WriteLine(id);
            List<Doctor> result = new List<Doctor>();
            result = doctorService.GetDoctorsBySpeciality(idSpecialty);
            return Ok(result);
        }

        [HttpGet("findDoctors")]
        public IActionResult GetAllDoctors()
        {
            return Ok(doctorService.GetAllDoctors());

        }
    }
}
