using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using Renci.SshNet;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using Integration.DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Integration.Service
{
    public class PrescriptionGenerationService
    {
        

        public PrescriptionGenerationService()
        {
           
        }

        public bool UploadDrugConsumptionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "user", "password")))
            {
                try
                {
                    client.Connect();
                    string sourceFile = FormatPath(fileName);
                    if (File.Exists(sourceFile))
                    {
                        using (Stream stream = File.OpenRead(sourceFile))
                        {
                            client.UploadFile(stream, @"\public\Drugstore files\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
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

        private string FormatPath(string fileName)
        {
            string[] absolute = Directory.GetCurrentDirectory().Split("src");
            return Path.Combine(absolute[0], "src\\Integration\\Reports\\" + fileName);
        }

        public bool UploadPrescription(PrescriptionDto prescriptionDto)
        {   bool returnVal = false;
            using (iTextSharp.text.pdf.PdfDocument Document = new iTextSharp.text.pdf.PdfDocument())
            {
                Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate().Rotate());
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("sample" + ".pdf", FileMode.Create));
                string FileName = "Prescription for " + prescriptionDto.PatientName;
                doc.AddTitle(FileName);
                doc.Open();
                ColumnText.ShowTextAligned(writer.DirectContent,
                    Element.ALIGN_LEFT, new Phrase("Prescription:"), 30, 800, 0);
                ColumnText.ShowTextAligned(writer.DirectContent,
                    Element.ALIGN_LEFT, new Phrase("Issued for: " + prescriptionDto.PatientName), 30, 760, 0);
                ColumnText.ShowTextAligned(writer.DirectContent,
                    Element.ALIGN_LEFT, new Phrase("Prescription issued: " + DateTime.Now.ToString("dd.MM.yyyy")), 30, 720, 0);
                ColumnText.ShowTextAligned(writer.DirectContent,
                    Element.ALIGN_LEFT, new Phrase("Prescripted drugs: " + prescriptionDto.Name), 30, 760, 0);
                ColumnText.ShowTextAligned(writer.DirectContent,
                    Element.ALIGN_LEFT, new Phrase("Description : " + prescriptionDto.Description), 30, 760, 0);
                UploadDrugConsumptionReport(FileName);
                doc.Close();
                returnVal = true;
            }
            return returnVal;
        }

    }
}
