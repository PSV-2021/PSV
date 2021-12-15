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
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Drugstore.Service
{
    public class DrugSpecificationService
    {
        public DrugSpecificationSqlRespository specificationRepository { get; set; }
        private string sftp_ip = Environment.GetEnvironmentVariable("SFTP_IP") ?? GetLocalIPAddress();
        private string sftp_name = Environment.GetEnvironmentVariable("SFTP_USERNAME") ?? "user";
        private string sftp_password = Environment.GetEnvironmentVariable("SFTP_PASSWORD") ?? "password";
        public DrugSpecificationService(MyDbContext dbContext) 
        {
            specificationRepository = new DrugSpecificationSqlRespository(dbContext);
        }

        public bool UploadDrugSpecification(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(sftp_ip, sftp_name, sftp_password)))
            {
                try
                {
                    client.Connect();
                    string sourceFile = FormatDrugsSpecificationsPath() + fileName + " - Specifikacija leka.pdf";
                    try
                    {
                        using (Stream stream = File.OpenRead(sourceFile))
                        {
                            string serverPath = "public" + Path.DirectorySeparatorChar + "HospitalFiles" + Path.DirectorySeparatorChar;
                            client.UploadFile(stream, serverPath + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });     
                        }
                    }
                    catch (Exception e)
                    {
                        string ErrorString = e.Message;
                    }
                    client.Disconnect();
                    return true;
                }
                catch (SocketException se)
                {
                    string ErrorString = se.Message;
                }
                return false;
            }
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
                Document.Save(FormatDrugsSpecificationsPath() + drugName + " - Specifikacija leka.pdf");
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

        private string FormatDrugsSpecificationsPath()
        {
            return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "DrugsSpecifications" + Path.DirectorySeparatorChar;
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
