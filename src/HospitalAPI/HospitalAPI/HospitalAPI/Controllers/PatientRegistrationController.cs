using Hospital.Model;
using Hospital.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
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
        public PatientService patientService;


        public PatientRegistrationController(MyDbContext context)
        {
            this.dbContext = context;
            patientService = new PatientService(new PatientSqlRepository(context));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Patient patient)
        {
            patientService.SavePatientSql(patient, dbContext);
           
            return Ok();
        }
    }
}
