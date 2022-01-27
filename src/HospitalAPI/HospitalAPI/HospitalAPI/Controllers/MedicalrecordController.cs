using Hospital.SharedModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Hospital.MedicalRecords.Service;
using Hospital.Schedule.Service;
using System.Linq;
using System.Threading.Tasks;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Model;
using HospitalAPI.DTO;
using Hospital.Schedule.Repository;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalrecordController : ControllerBase
    {
        private readonly MyDbContext context;
        public MedicalRecordService medicalRecordService = new MedicalRecordService();
        public PatientService patientService = new PatientService();
        public DoctorService doctorService = new DoctorService();


        public MedicalrecordController(MyDbContext context)
        {
            this.context = context;
            medicalRecordService = new MedicalRecordService(new MedicalRecordSqlRepository(context));
            patientService = new PatientService(new PatientSqlRepository(context));
            doctorService = new DoctorService(new DoctorSqlRepository(context));
            patientService.AllergenRepository = new AllergenSqlRepository(context);
        }

 
        //[Authorize(Roles = "patient")]
        [HttpGet]
        public IActionResult Get( string id)
        {
            int idPatient = Int32.Parse(id);

            Patient resultPatient = patientService.GetPatientById(idPatient);
            MedicalRecordDTO result = new MedicalRecordDTO(resultPatient);
            result.Allergens = patientService.GetAllergensById(idPatient);
            result.DoctorName = doctorService.GetDoctorById(resultPatient.DoctorId);
            return Ok(result);
        }
    }
}
