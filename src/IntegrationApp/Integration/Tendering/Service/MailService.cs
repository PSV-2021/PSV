using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.Model;
using Integration.Repository.Sql;
using Integration.Tendering.Model;
using Integration_API.Repository.Interfaces;
using iText.Layout.Element;
using MailKit.Net.Smtp;
using MimeKit;
using Model.DataBaseContext;

namespace Integration.Tendering.Service
{
    public class MailService
    {
        public IDrugstoreRepository DrugstoreRepository { get; set; }
        public MailService(IDrugstoreRepository drugstoreRepository)
        {
            DrugstoreRepository = drugstoreRepository;
        }

        public MailService(MyDbContext db)
        {
            DrugstoreRepository = new DrugstoreSqlRepository(db);
        }

        public MailService()
        {
            this.DrugstoreRepository = new DrugstoreSqlRepository();
        }

        public void SendEmailForTenderWin(Drugstore drugstore, TenderOffer offer)
        {
            if (drugstore == null && offer == null)
                return;
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Hospital Srbija", "crnimraz99@gmail.com")); //ne zamerite nemam bolji :(

            message.To.Add(MailboxAddress.Parse(drugstore.Email.EmailValue));

            message.Subject = "You have just won on tender!";

            message.Body = new TextPart("plain")
            {
                Text = @"You have just won tender with you offer:" + Environment.NewLine + offer.TenderOfferInfo +
                       " " + Environment.NewLine + "With price:" + offer.Price + "RSD."
                
            };

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("crnimraz99@gmail.com", "cokolada_2000"); //ne osudjuj!
                client.Send(message);
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

        public void SendEmailForTenderLoser(Drugstore drugstore, TenderOffer offer)
        {
            if (drugstore == null && offer == null)
                return;
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Hospital Srbija", "crnimraz99@gmail.com")); //ne zamerite nemam bolji :(

            message.To.Add(MailboxAddress.Parse(drugstore.Email.EmailValue));

            message.Subject = "You have just won on tender!";

            message.Body = new TextPart("plain")
            {
                Text = @"Your tender offer " + offer.TenderOfferInfo + " with price:" + offer.Price + " is not accepted."

            };

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("crnimraz99@gmail.com", "cokolada_2000"); //ne osudjuj!
                client.Send(message);
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
