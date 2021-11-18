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
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext context;
        public DoctorSqlRepository doctorSqlRepository = new DoctorSqlRepository();
        public DoctorsController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            doctorSqlRepository.dbContext = context;
            List<Doctor> result = new List<Doctor>();
            result = doctorSqlRepository.GetAll();
            return Ok(result);
        }
    }
}
