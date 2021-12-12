using Renci.SshNet;
using Renci.SshNet.Sftp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace Drugstore.Service
{
    public class DrugsConsumptionReportService
    {
        private string ipaddress;
        private string username;
        private string password;
        public DrugsConsumptionReportService(string ipaddress, string username, string password)
        {
            this.ipaddress = ipaddress;
            this.username = username;
            this.password = password;
        }
        public void DownloadDrugConsumtpionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(this.ipaddress, this.username, this.password)))
            {
                    client.Connect();
                    string localFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar +  "Reports" + Path.DirectorySeparatorChar+"test.txt";//FIX
                    using (Stream stream = File.OpenWrite(localFile))
                    {
                        client.DownloadFile(fileName, stream, x => Console.WriteLine(x));
                        client.Delete(fileName);
                    }
                    client.Disconnect();
            }
        }

        public void DownloadDrugConsupationReports()
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(this.ipaddress, this.username, this.password)))
            {
                client.Connect();
                string serverPath = "public" + Path.DirectorySeparatorChar + "DrugstoreFiles" + Path.DirectorySeparatorChar;
                client.ChangeDirectory("public" + Path.DirectorySeparatorChar + "DrugstoreFiles");
                DownloadAllFilesToLocal(client, ".txt");
                client.Disconnect();
            }
        }

        private void DownloadAllFilesToLocal(SftpClient client, string fileExtension)
        {
            foreach (string path in GetAllFilesPathsToCompress(client, fileExtension))
            {
                if(File.GetCreationTime(path).CompareTo(DateTime.Now.AddMonths(-6)) < 0)
                DownloadDrugConsumtpionReport(path);
            }
        }

        private List<String> GetAllFilesPathsToCompress(SftpClient client, string fileExtenstion) {
            List<SftpFile> filePaths = (List<SftpFile>)client.ListDirectory(client.WorkingDirectory); 
            return (List<string>)filePaths.Where(path => path.FullName.EndsWith(fileExtenstion)).Select(path=>path.FullName).ToList();
        }

        public bool UploadDrugConsumptionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(ipaddress, username, password)))
            {
                try
                {
                    client.Connect();
                    string sourceFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "ReportsCompressed" + Path.DirectorySeparatorChar + fileName;
                    if (File.Exists(sourceFile))
                    {
                        using (Stream stream = File.OpenRead(sourceFile))
                        {
                            client.UploadFile(stream, "public" + Path.DirectorySeparatorChar + "CompressedDrugstoreFiles" + Path.DirectorySeparatorChar + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
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

    }
}
