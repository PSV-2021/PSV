using Renci.SshNet;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

namespace Drugstore.Service
{
    public class DrugSpecificationService
    {
        public DrugSpecificationService() { }

        public bool UploadDrugSpecification(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "user", "password")))
            {
                client.Connect();

                string sourceFile = @"D:\PSV\src\DrugstoreApp\Backend\DrugstoreAPI\Drugstore\Drug Specifications\" + fileName + " - Specifikacija leka.pdf";
                if (File.Exists(sourceFile))
                {
                    using (Stream stream = File.OpenRead(sourceFile))
                    {
                        client.UploadFile(stream, @"\public\Hospital files\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
                        client.Disconnect();
                        return true;
                    }
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
                Document.Save(@"D:\PSV\src\DrugstoreApp\Backend\DrugstoreAPI\Drugstore\Drug Specifications\" + drugName + " - Specifikacija leka.pdf");
                Document.Close(true);
            }
        }

        public string ReadDrugSpecification(string drugName)
        {
            drugName = drugName.Trim();
            drugName = char.ToUpper(drugName[0]) + drugName.Substring(1).ToLower();
            string path = @"D:\PSV\src\DrugstoreApp\Backend\DrugstoreAPI\Drugstore\Drug Specifications\" + drugName + ".txt";

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return "";
        }
    }
}
