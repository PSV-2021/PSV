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
    public class PatientRegistrationController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public PatientSqlRepository patientSqlRepository = new PatientSqlRepository();


        public PatientRegistrationController(MyDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public IActionResult Post(Patient patient)
        {
            patientSqlRepository.dbContext = dbContext;
            Patient newPatient = patient;
            patientSqlRepository.SavePatient(newPatient);
            return Ok();
        }
    }
}
