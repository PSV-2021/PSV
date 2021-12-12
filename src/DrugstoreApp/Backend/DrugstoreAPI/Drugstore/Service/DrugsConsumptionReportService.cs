using Renci.SshNet;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;

namespace Drugstore.Service
{
    public class DrugsConsumptionReportService
    {
        public bool DownloadDrugConsumtpionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.1.107", "user", "password")))
            {
                client.Connect();
                string serverFile = @"\public\HospitalFiles\" + fileName + ".pdf";
                if (File.Exists(serverFile))
                {
                    string localFile = "..\\..\\src\\DrugstoreApp\\Backend\\DrugstoreAPI\\Drugstore\\Reports\\" + fileName + ".pdf";
                    using (Stream stream = File.OpenWrite(localFile))
                    {
                        client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
                    }
                    client.Disconnect();
                    return true;
                }
                return false;
            }
        }
    }
}
