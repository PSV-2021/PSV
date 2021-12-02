using HospitalAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using MessagingToolkit.QRCode.Codec;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        [HttpPost("qrprescription")]
        public IActionResult QrPrescription(PrescriptionDto prescription)
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("/api/drugpurchase", Method.PUT);

            SetApiKeyInHeader(request);

            SetRequestBody(prescription, request);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(false);
            }

            client = new RestClient("http://localhost:5000");
            request = new RestRequest("/api/prescription/qr", Method.POST);

            SetApiKeyInHeaderForQr(prescription ,request);

            //SetPdfInBody(prescription, request);
            SetRequestBody(prescription, request);

            IRestResponse responseSecond = client.Execute(request);
            if (responseSecond.StatusCode != HttpStatusCode.OK)
                return BadRequest("Some error occured!");
            return Ok(responseSecond.Content);
        }
        private static void SetRequestBody(PrescriptionDto prescription, RestRequest request)
        {
            var body = new
            {
                Name = prescription.Name,
                Amount = 1,
                PharmacyUrl = prescription.PharmacyUrl,
                Description = prescription.Description,
                PatientName = prescription.PatientName
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);
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

        private void SetApiKeyInHeader(RestRequest request)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", "abcde");
        }

        private void SetApiKeyInHeaderForQr(PrescriptionDto prescription , RestRequest request)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", "abcde");
            //request.AddHeader("Url", prescription.PharmacyUrl);
            //request.AddHeader("Patient", prescription.PatientName);
        }
    }
}
