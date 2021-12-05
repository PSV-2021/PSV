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

        [HttpGet("/chooseDoctor/{id}")]
        public IActionResult GetDoctorsBySpecialty(int id)
        {
            List<Doctor> result = new List<Doctor>();
            result = doctorService.GetDoctorsBySpeciality(id);
            return Ok(result);
        }
    }
}
