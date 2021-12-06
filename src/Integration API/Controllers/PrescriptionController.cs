using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DataBaseContext;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Integration_API.DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MessagingToolkit.QRCode.Codec;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public PrescriptionController(MyDbContext db)
        {
            dbContext = db;
        }

        [HttpPost("qr")]
        public IActionResult QrPerscription([FromBody] PrescriptionDto prescription)
        {
            var key = Request.Headers["ApiKey"].FirstOrDefault();
            if (key == null || !key.Equals("abcde"))
                return Unauthorized();

            //var url = Request.Headers["Url"].FirstOrDefault();
            if (prescription.PharmacyUrl == null)
                return BadRequest();

            //var name = Request.Headers["Patient"].FirstOrDefault();
            if (prescription.PatientName == null)
                return BadRequest();

            var client = new RestClient(prescription.PharmacyUrl);
            var request = new RestRequest("/api/prescription/qr", Method.POST);

            SetApiKeyInHeaderQr(prescription.PharmacyUrl, prescription.PatientName, request);
            SetPdfInBody(prescription, request);
            //request.AddJsonBody(file);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Content);
            }

            return BadRequest("Something went wrong");
        }

        private void SetApiKeyInHeaderQr(string url, string name, RestRequest request)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Url.Equals(url))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", ApiKey);
            request.AddHeader("Patient", name);
        }

        private static void CreatePrescriptionPdf(PrescriptionDto prescription)
        {
            Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate().Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("sample" + ".pdf", FileMode.Create));
            doc.Open();
            ColumnText.ShowTextAligned(writer.DirectContent,
                Element.ALIGN_LEFT, new Phrase("Prescription:"), 30, 800, 0);
            ColumnText.ShowTextAligned(writer.DirectContent,
                Element.ALIGN_LEFT, new Phrase("Issued for: " + prescription.PatientName), 30, 760, 0);
            ColumnText.ShowTextAligned(writer.DirectContent,
                Element.ALIGN_LEFT, new Phrase("Prescription issued: " + DateTime.Now.ToString("dd.MM.yyyy")), 30, 720, 0);

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("code.jpg");
            image.SetAbsolutePosition(30, 600);
            image.ScaleToFit(100f, 100f);
            doc.Add(image);
            doc.Close();
        }

        private void SetPdfInBody(PrescriptionDto prescription, RestRequest request)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap bi = encoder.Encode(prescription.Name + System.Environment.NewLine + prescription.Description);
            bi.Save("code.jpg", ImageFormat.Jpeg);

            CreatePrescriptionPdf(prescription);

            var file = TransformPdfToBase64();
            request.AddJsonBody(file);
        }

        private static string TransformPdfToBase64()
        {
            string entitySource = @"sample.pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(entitySource);
            string file = Convert.ToBase64String(bytes);
            return file;
        }
    }
}
