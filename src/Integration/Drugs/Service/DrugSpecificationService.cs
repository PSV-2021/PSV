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
        public DrugSpecificationService() { }

        public bool DownloadDrugConsumptionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "user", "password")))
            {
                try
                {
                    client.Connect();
                    string serverFile = @"\public\Hospital files\" + fileName;
                    
                    if (File.Exists(FormatRebexPath() + fileName))
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

        private string FormatRebexPath()
        {
            string[] absolute = Directory.GetCurrentDirectory().Split("src");
            return Path.Combine(absolute[0], "src\\Rebex\\data\\public\\Hospital files\\");
        }

        private string FormatFilePath(string fileName)
        {
            string[] absolute = Directory.GetCurrentDirectory().Split("src");
            return Path.Combine(absolute[0], "src\\Integration\\Drugs Specifications\\" + fileName);
        }

        public List<FileInfoDto> GetFiles()
        {
            List<FileInfoDto> filenames = new List<FileInfoDto>();
            DirectoryInfo d = new DirectoryInfo(@"..\\..\\src\\Rebex\\data\\public\\Hospital files");
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
            DirectoryInfo d = new DirectoryInfo(@"..\\..\\src\\Integration\\Drugs Specifications");
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
