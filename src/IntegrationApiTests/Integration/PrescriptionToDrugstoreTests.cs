using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Integration_API.Controllers;
using Integration_API.DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Xunit;

namespace IntegrationApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class PrescriptionToDrugstoreTests
    {
        private MyDbContext context;
        private void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }
        [Fact]
        public void Check_if_not_valid_url_is_sent()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";
            //httpContext.Request.Headers["Url"] = @"http://localhost:5005";
            //httpContext.Request.Headers["Patient"] = "Test testic";

            var controler = new PrescriptionController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPerscription(new PrescriptionDto(@"http://localhost:5005", "Lek", 1, "Neki opis", "Ime Prezime"));

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Check_if_everything_went_good()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";
            //httpContext.Request.Headers["Url"] = @"http://localhost:5001";
            //httpContext.Request.Headers["Patient"] = "Test testic";

            var controler = new PrescriptionController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
            Document doc = new Document(PageSize.A4.Rotate().Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("test" + ".pdf", FileMode.Create));
            doc.Open();
            ColumnText.ShowTextAligned(writer.DirectContent,
                Element.ALIGN_LEFT, new Phrase("TEST"), 30, 800, 0);
            doc.Close();
            string entitySource = @"test.pdf";
            byte[] bytes = File.ReadAllBytes(entitySource);
            string file = Convert.ToBase64String(bytes);

            var result = controler.QrPerscription(new PrescriptionDto(@"http://localhost:5001", "Brufen", 1, "Neki opis", "Ime Prezime"));

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
