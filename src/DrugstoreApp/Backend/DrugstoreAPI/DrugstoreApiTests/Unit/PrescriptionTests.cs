using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DrugstoreAPI.Controllers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace DrugstoreApiTests.Unit
{
    
    public class PrescriptionTests
    {
        [Fact]
        public void Check_if_ApiKey_is_not_valid()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "something wrong";

            var controler = new PrescriptionController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPerscription("");

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void Check_if_patient_name_is_not_sent()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "DrugStoreSecretKey";

            var controler = new PrescriptionController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPerscription("");

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Check_if_file_is_saved()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "DrugStoreSecretKey";
            httpContext.Request.Headers["Patient"] = "Test Testic";

            var controler = new PrescriptionController(null)
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

            var result = controler.QrPerscription(file);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
