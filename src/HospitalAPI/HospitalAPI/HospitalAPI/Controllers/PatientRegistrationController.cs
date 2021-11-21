using Hospital.DTO;
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
        public IActionResult Post([FromBody] PatientDTO p)
        {
            Patient patient = GeneratePatientFromDTO(p);
            patientService.SavePatientSql(patient, dbContext);

            return Ok();
        }

        private static Patient GeneratePatientFromDTO(PatientDTO p)
        {
            Patient patient = new Patient
            {
                Name = p.Name,
                Surname = p.Surname,
                Jmbg = p.Jmbg,
                BloodType = p.BloodType,
                FathersName = p.FathersName,
                Sex = p.Sex,
                Adress = p.Address,
                Email = p.Email,
                Username = p.Username,
                PhoneNumber = p.PhoneNumber,
                Password = p.Password,
                DoctorId = p.DoctorId
            };
            patient.Allergen = new List<Allergen>();
            foreach (String s in p.Allergens)
            {
                patient.Allergen.Add(new Allergen { Name = s, PatientId = patient.Id});
            }
            patient.DateOfBirth = DateTime.Parse(p.Date);
            patient.Type = UserType.patient;

            return patient;
        }
    }
}
