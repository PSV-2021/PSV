using Hospital.DTO;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.SharedModel;
using Microsoft.AspNetCore.Authorization;
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
    public class LoginController : ControllerBase
    {
        private MyDbContext context;
        public PatientService patientService;

        public LoginController(MyDbContext context)
        {
            this.context = context;
            patientService = new PatientService(new PatientSqlRepository(context));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authentication(UserDTO userDTO)
        {
            Patient patient = patientService.FindByUsernameAndPassword(userDTO.Username, userDTO.Password);

            if(patient != null)
            {
                String jwtToken = patientService.GenerateJwtToken(patient);
                return Ok(jwtToken);
            }else
                return Unauthorized();
        }
    }
}
