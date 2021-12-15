using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Hospital.SharedModel;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using NETCore.MailKit.Core;
using Hospital.Service;
using HospitalAPI.DTO;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailValidationController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public PatientSqlRepository patientSqlRepository = new PatientSqlRepository();
        private IEmailService emailService;
        private PatientService patientService;

        public EmailValidationController(MyDbContext context)
        {
            this.dbContext = context;
        }

      /*  [HttpPost]
        public IActionResult Post(Patient patient)
        {
            patientSqlRepository.dbContext = dbContext;
            patientSqlRepository.SavePatient(patient);

            patientSqlRepository.saveToken(patient);
            
            return Ok();
        }*/

        [HttpPost]   
        public IActionResult Post([FromBody] PatientDto p)
        {
            Patient patientNew = new Patient
            {
                Token = p.Token,
            };
            patientSqlRepository.dbContext = dbContext;
            Patient patient = (from n in dbContext.Patients where (n.Token == patientNew.Token && n.IsActive == false) select n).First();
            patientSqlRepository.activateAccount(patient.Id, patient.Token);
            return Ok();
        }

        public async void sendMail(Patient patient, string link1)
        {
            MailService mailService = new MailService();

            var message = new MailMessage();
            message.To.Add("firma4validation@gmail.com");
            string link = link1 + "/user/activate?token=" + patient.Token;
            try
            {
           //     string url = Url.Action(nameof(Activate), "Registration", new { userId = patient.Id, token = patient.Token });
                message.IsBodyHtml = true;
                message.Subject = "Aktivacioni link za Vaš nalog";
                message.Body = "Molimo potvrdite registraciju klikom na \n" + " <a href='[link2]' >'[link]'</a> ";
                message.Body = message.Body.Replace("[link]", link);
           //     message.Body = message.Body.Replace("[link2]", url);
            }catch(Exception e)
            {

            }

            message.IsBodyHtml = true;
            message.Subject = "aktivacioni link za vaš nalog";
            message.Body = "molimo potvrdite registraciju klikom na \n" + " <a href='[link2]' >'[link]'</a> ";
            message.Body = message.Body.Replace("[link]", link);
            message.Body = message.Body.Replace("[link2]", link);


            message.From = new MailAddress("firma4validation@gmail.com");
            try
            {
                
                await mailService.SendMailAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
            }
        }

        public IActionResult Activate(int userId, string token)
        {
            if (patientSqlRepository.activateAccount(userId, token) == true) return Ok(token);

            else return Ok();
           
        }
        private string GetLink(Patient patient)
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "4200";
            string domport = $"http://{domain}:{port}";

            return domport ;

        }

    }
}
