using Microsoft.AspNetCore.Mvc;
using Model.DataBaseContext;
using RestSharp;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using Integration_API.DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MessagingToolkit.QRCode.Codec;
using Integration.Service;
using Renci.SshNet;
using System.Net.Sockets;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private string sftp_ip = Environment.GetEnvironmentVariable("SFTP_IP") ?? GetLocalIPAddress();
        private string sftp_name = Environment.GetEnvironmentVariable("SFTP_USERNAME") ?? "user";
        private string sftp_password = Environment.GetEnvironmentVariable("SFTP_PASSWORD") ?? "password";
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




        [HttpPost("pdf")]
        public IActionResult PdfPerscription( PrescriptionDto prescription)
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


            bool val = GenerateAndUploadPrescription(prescription);
            if(val)    
            return Ok(val);
            else            
            return BadRequest(val);
        }

        
        public bool UploadPrescription(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(sftp_ip, sftp_name, sftp_password)))
            {
                try
                {
                    client.Connect();
                    string sourceFile = FormatReportsPath() + fileName;
                    if (System.IO.File.Exists(sourceFile))
                    {
                        using (Stream stream = System.IO.File.OpenRead(sourceFile))
                        {
                            client.UploadFile(stream, "public" + Path.DirectorySeparatorChar + "DrugstoreFiles" + Path.DirectorySeparatorChar + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
                            client.Disconnect();
                            return true;
                        }
                    }
                }
                catch (SocketException se)
                {
                    string ErrorString = se.Message;
                }
                return false;
            }
        }
        //private string FormatPath(string fileName)
        //{
        //    string[] absolute = Directory.GetCurrentDirectory().Split("src");
        //    return Path.Combine(absolute[0], "src\\Integration\\Reports\\" + fileName);
        //}
        public bool GenerateAndUploadPrescription(PrescriptionDto prescriptionDto)
        {
            bool returnVal = false;
            using (Syncfusion.Pdf.PdfDocument Document = new Syncfusion.Pdf.PdfDocument())
            {
                Syncfusion.Pdf.PdfPage Page = Document.Pages.Add();
                PdfGraphics Graphics = Page.Graphics;
                Syncfusion.Pdf.Graphics.PdfFont HeaderFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                Syncfusion.Pdf.Graphics.PdfFont BodyFont = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
                Graphics.DrawString(" Recept za " + prescriptionDto.PatientName , HeaderFont, PdfBrushes.Blue, new PointF(120, 20));
                Graphics.DrawString("Detalji: " + prescriptionDto.Description, BodyFont, PdfBrushes.Black, new PointF(90, 60));
                Graphics.DrawString("Lekovi: " + prescriptionDto.Name, BodyFont, PdfBrushes.Black, new PointF(90, 50));
                Graphics.DrawString("Datum izdavanja " + DateTime.Now.ToShortDateString(), BodyFont, PdfBrushes.Black, new PointF(90, 40));
               
                string FileName = "Recept " + prescriptionDto.PatientName + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + " " + DateTime.Now.Hour + "." + DateTime.Now.Minute + ".pdf";
                string localFile = FormatReportsPath() + FileName;
                Document.Save(localFile);
                Document.Close(true);
                UploadPrescription(FileName);
                 returnVal = true;
            }
            return returnVal;
        }
        private string FormatReportsPath()
        {
            return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Reports" + Path.DirectorySeparatorChar;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
