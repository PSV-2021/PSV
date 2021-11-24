using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.SharedModel;
using HospitalAPI.DTO;
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
    public class ValidationController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public PatientSqlRepository patientSqlRepository = new PatientSqlRepository();
        private PatientService patientService;

        public ValidationController(MyDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PatientDto p)
        {
            Patient patientNew = new Patient
            {
                Token = p.Token,
            };
            Console.WriteLine(patientNew.Token);
            patientSqlRepository.dbContext = dbContext;
            Patient patient = (from n in dbContext.Patients where n.Token == patientNew.Token  select n).First();
            if(patientSqlRepository.activateAccount(patient.Id, patient.Token) == true) return Ok();
            else return BadRequest();
        }
    }
}
