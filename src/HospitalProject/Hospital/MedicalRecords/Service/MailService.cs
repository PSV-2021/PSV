using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using SendGrid.Helpers.Mail;

namespace Hospital.Service
{
     public class MailService 
     {
            public string Mail { get; set; }
            public string DisplayName { get; set; }
            public string Password { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }

            private readonly MailSettings mailSettings;
            public MailService(IOptions<MailSettings> mailSettings)
            {
                this.mailSettings = mailSettings.Value;
            }
            public MailService() { }

            public async Task SendMailAsync(MailMessage message)
            {


                using (var smtpClient = new System.Net.Mail.SmtpClient())
                {

                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    NetworkCredential nc = new NetworkCredential("firma4validation@gmail.com", "firma4val!");
                    smtpClient.Credentials = nc;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    await smtpClient.SendMailAsync(message);
                }

        }

            
    }
}
