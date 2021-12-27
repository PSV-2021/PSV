using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.SharedModel;
using HospitalAPI.DTO;
using Hospital.Service;
using System.Net.Mail;
using HospitalAPI.Verification;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRegistrationController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public PatientService patientService;
        private MailService mailService = new MailService();
        public PatientVerification patientVerification = new PatientVerification();


        public PatientRegistrationController(MyDbContext context)
        {
            this.dbContext = context;
            patientService = new PatientService(new PatientSqlRepository(context));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PatientDto p)
        {
            if (!patientVerification.Verify(p))     return BadRequest();
            Patient patient = GeneratePatientFromDTO(p);
            patientService.SavePatientSql(patient, dbContext);
            string link = GetLink(patient);
            sendMail(patient, link);
            return Ok();
        }

        private static Patient GeneratePatientFromDTO(PatientDto p)
        {
          TokenGenerator tokenGenerator = new TokenGenerator();
            Patient patient = new Patient(p.Name, p.Surname, p.Jmbg, p.BloodType, p.FathersName, p.Sex, p.Address, p.Email, p.Username, p.PhoneNumber, p.Password, p.DoctorId,
                tokenGenerator.getNewToken(), new List<Allergen>(), p.Image);
            foreach (String s in p.Allergens)   patient.Allergen.Add(new Allergen(patient.Id, s));
            patient.DateOfBirth = DateTime.ParseExact(p.Date, "dd/MM/yyyy hh:mm:ss", null);
            //patient.DateOfBirth = DateTime.Parse(p.Date);
            patient.Type = UserType.patient;
            return patient;
        }
        private string GetLink(Patient patient)
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "4200";
            return $"http://{domain}:{port}";
        }

        public async void sendMail(Patient patient, string linkPart)
        {
            var message = new MailMessage();
            string link = linkPart + "/user/activate?token=" + patient.Token;
            formMessage(message);
            message.Body = message.Body.Replace("[link]", link);
            message.Body = message.Body.Replace("[link2]", link);

            try
            {
                await mailService.SendMailAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
            }
        }
        private MailMessage formMessage(MailMessage message)
        {
            message.To.Add("firma4validation@gmail.com");
            message.IsBodyHtml = true;
            message.Subject = "Aktivacioni link za vaš nalog";
            message.Body = "Molimo potvrdite registraciju klikom na \n" + " <a href='[link2]' >'[link]'</a> ";
            message.From = new MailAddress("firma4validation@gmail.com");
            return message;
        }
    }
}
