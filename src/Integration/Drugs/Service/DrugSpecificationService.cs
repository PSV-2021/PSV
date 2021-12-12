using Integration.Drugs.DTOs;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Integration.Drugs.Service
{
    public class DrugSpecificationService
    {
        private string sftp_ip = Environment.GetEnvironmentVariable("SFTP_IP") ?? "192.168.1.107";
        private string sftp_name = Environment.GetEnvironmentVariable("SFTP_USERNAME") ?? "user";
        private string sftp_password = Environment.GetEnvironmentVariable("SFTP_PASSWORD") ?? "password";
        public DrugSpecificationService() 
        {
        }

        public bool DownloadDrugConsumptionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(this.sftp_ip, this.sftp_name, this.sftp_password)))
            {
                try
                {
                    client.Connect();
                    string serverFile = "public" + Path.DirectorySeparatorChar + "HospitalFiles" + Path.DirectorySeparatorChar + fileName;
                    if (File.Exists(serverFile + fileName))
                    {
                        string localFile = FormatFilePath(fileName);
                        using (Stream stream = File.OpenWrite(localFile))
                        {
                            client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
                        }
                        client.Disconnect();
                        return true;
                    }
                }
                catch (SocketException se)
                {
                    string ErrorString = se.Message;
                }
                return false;
            }
        }

        

        private string FormatFilePath(string fileName)
        {
            string[] absolute = Directory.GetCurrentDirectory().Split("src");
            return Path.Combine(absolute[0], "src\\ManagerAngularApp\\ManagerAngularApp\\src\\assets\\DrugsSpecifications\\" + fileName);
        }

        public List<FileInfoDto> GetFiles()
        {
            List<FileInfoDto> filenames = new List<FileInfoDto>();
            DirectoryInfo d = new DirectoryInfo(@"..\\..\\src\\Rebex\\data\\public\\HospitalFiles");
            FileInfo[] Files = d.GetFiles("*.pdf");
            foreach (FileInfo file in Files)
            {
                if (IsFileDownloaded(file.Name))
                    filenames.Add(new FileInfoDto(file.Name, true));
                else
                    filenames.Add(new FileInfoDto(file.Name, false));
            }
            return filenames;
        }

        public bool IsFileDownloaded(string filename)
        {
            bool retVal = false;
            DirectoryInfo d = new DirectoryInfo(@"..\\..\\src\\ManagerAngularApp\\ManagerAngularApp\\src\\assets\\DrugsSpecifications\\");
            FileInfo[] Files = d.GetFiles("*.pdf");
            foreach (FileInfo file in Files)
            {
                if (file.Name.Equals(filename))
                    retVal = true;
            }
            return retVal;
        }
    }
}
