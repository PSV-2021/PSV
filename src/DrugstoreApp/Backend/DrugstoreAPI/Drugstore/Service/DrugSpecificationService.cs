using Drugstore.Models;
using Drugstore.Repository.Sql;
using Renci.SshNet;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Drugstore.Service
{
    public class DrugSpecificationService
    {
        public DrugSpecificationSqlRespository specificationRepository { get; set; }
        public DrugSpecificationService(MyDbContext dbContext) 
        {
            specificationRepository = new DrugSpecificationSqlRespository(dbContext);
        }

        public bool UploadDrugSpecification(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "user", "password")))
            {
                try
                {
                    client.Connect();
                    string sourceFile = FormatPath() + fileName + " - Specifikacija leka.pdf";
                    if (File.Exists(sourceFile))
                    {
                        using (Stream stream = File.OpenRead(sourceFile))
                        {
                            client.UploadFile(stream, @"\public\HospitalFiles\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
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

        public void SaveDrugSpecification(string drugName, string specification)
        {
            using (PdfDocument Document = new PdfDocument())
            {
                PdfPage Page = Document.Pages.Add();
                PdfGraphics Graphics = Page.Graphics;
                PdfFont HeaderFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                PdfFont BodyFont = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
                Graphics.DrawString(drugName + " - Specifikacija leka", HeaderFont, PdfBrushes.Blue, new PointF(120, 20));
                Graphics.DrawString(specification, BodyFont, PdfBrushes.Black, new PointF(90, 50));
                Document.Save(FormatPath() + drugName + " - Specifikacija leka.pdf");
                Document.Close(true);
            }
        }

        public string ReadDrugSpecification(string drugName)
        {
            foreach (DrugSpecification ds in specificationRepository.GetAll())
            {
                if (ds.Name.Equals(drugName))
                {
                    return ds.Text;
                }
            }
            return "";
        }

        private string FormatPath()
        {
            string[] absolute = Directory.GetCurrentDirectory().Split("src");
            return Path.Combine(absolute[0], "src\\DrugstoreApp\\Backend\\DrugstoreAPI\\Drugstore\\DrugsSpecifications\\");
        }

        private string FormatString(string drugName)
        {
            if (drugName != "")
            {
                drugName = drugName.Trim();
                drugName = char.ToUpper(drugName[0]) + drugName.Substring(1).ToLower();
            }
            return drugName;
        }
    }
}
