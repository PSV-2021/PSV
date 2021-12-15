using Integration.Drugs.DTOs;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Integration.Drugs.Service
{
    public class DrugSpecificationService
    {
        private string sftp_ip = Environment.GetEnvironmentVariable("SFTP_IP") ?? GetLocalIPAddress();
        private string sftp_name = Environment.GetEnvironmentVariable("SFTP_USERNAME") ?? "user";
        private string sftp_password = Environment.GetEnvironmentVariable("SFTP_PASSWORD") ?? "password";
        public DrugSpecificationService() 
        {
        }

        public bool DownloadDrugSpecification(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(this.sftp_ip, this.sftp_name, this.sftp_password)))
            {
                try
                {
                    client.Connect();
                    string serverFile = "public" + Path.DirectorySeparatorChar + "HospitalFiles" + Path.DirectorySeparatorChar + fileName;
                    string localFile = FormatDrugsSpecificationsPath() + fileName;
                    try
                    {
                        using (Stream stream = File.OpenWrite(localFile))
                        {
                            client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
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

        private string FormatDrugsSpecificationsPath()
        {
            return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "DrugsSpecifications" + Path.DirectorySeparatorChar;
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

        public List<FileInfoDto> GetFiles()
        {
            List<string> Files = GetFormattedFiles(GetHospitalFilesInfo());
            List<FileInfoDto> filenames = new List<FileInfoDto>();
            foreach (string fileName in Files)
            {
                if (IsFileDownloaded(fileName))
                    filenames.Add(new FileInfoDto(fileName, true));
                else
                    filenames.Add(new FileInfoDto(fileName, false));
            }
            return filenames;
        }

        private List<string> GetFormattedFiles(List<string> notFormattedFiles)
        {
            List<string> fileNames = new List<string>();
            foreach (string s in notFormattedFiles)
            {
                string[] name = s.Split("HospitalFiles");
                fileNames.Add(name[1].Substring(1));
            }
            return fileNames;
        }

        public List<string> GetHospitalFilesInfo()
        {
            List<String> retList = new List<string>();
            try
            {
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo(sftp_ip, sftp_name, sftp_password)))
                {
                    client.Connect();
                    client.ChangeDirectory("public" + Path.DirectorySeparatorChar + "HospitalFiles");
                    retList = GetFilePaths(client, ".pdf");
                    client.Disconnect();
                    return retList;
                }
            }
            catch (Exception e)
            {
                string ErrorString = e.Message;
            }
            return retList;
        }

        private List<string> GetFilePaths(SftpClient client, string fileExtenstion)
        {
            List<SftpFile> filePaths = (List<SftpFile>)client.ListDirectory(client.WorkingDirectory);
            return (List<string>)filePaths.Where(path => path.FullName.EndsWith(fileExtenstion)).Select(path => path.FullName).ToList();
        }


        public bool IsFileDownloaded(string filename)
        {
            bool retVal = false;
            DirectoryInfo d = new DirectoryInfo(FormatDrugsSpecificationsPath());
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
