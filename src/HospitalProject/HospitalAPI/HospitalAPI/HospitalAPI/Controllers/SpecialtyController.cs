using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Hospital.SharedModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private MyDbContext context;
        public SpecialtyService specialtyService;

        public SpecialtyController(MyDbContext context)
        {
            this.context = context;
            specialtyService = new SpecialtyService(new SpecialtySqlRepository(context));

        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Speciality> result = new List<Speciality>();
            result = specialtyService.GetAllSpecialty();

            return Ok(result);
        }
    }
}
