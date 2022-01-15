using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Drugstore.Service
{
    public class MailService
    {
        public IHospitalRepository HospitalRepository { get; set; }
        public MailService(IHospitalRepository hospitalRepository)
        {
            HospitalRepository = hospitalRepository;
        }

        public MailService()
        {
            HospitalRepository = new HospitalSqlRepository();
        }
        public void SendEmailAboutUrgentPurchase(string drugName, int drugAmount, string apiKey)
        {
            Hospital hospital = HospitalRepository.GetAll().Where(hospital => hospital.ApiKey.Equals(apiKey)).FirstOrDefault();
            if (hospital == null)
                return;
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Drugstore", "smrdic99@gmail.com")); //ne zamerite nemam bolji :(

            message.To.Add(MailboxAddress.Parse(hospital.Email));

            message.Subject = "Succesfull drug purchase!";

            message.Body = new TextPart("plain")
            {
                Text = @"You have successfully purchased " + drugAmount + " " + drugName
            };

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("smrdic99@gmail.com", "cokolada");
                client.Send(message);
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAA");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }

        }
    }
}
