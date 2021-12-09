using Renci.SshNet;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using Aspose.Zip;
using Aspose.Zip.Saving;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Timers;

namespace Drugstore.Service
{
    public class FileCompressionService 
    {

        private List<FileInfo> fileInfos = new List<FileInfo>();
        private List<string> fileDeletionList = new List<string>();
        private string path = @"\PSV\src\Rebex\data\public\Drugstore files\";

        public  void CompressOldFiles()
        {
            string zipName = @"\PSV\src\Rebex\data\public\Compressed Drugstore files\Kompersovano-" + DateTime.Now.Day.ToString() + "." +
                DateTime.Now.Month.ToString()
                + "." + DateTime.Now.Year.ToString()
                + ". " + DateTime.Now.Hour.ToString()
                + " i " + DateTime.Now.Minute.ToString()
                + ".zip";

            if (this.CheckIfThereAreFIlesToCompress(path))
            {
                using (FileStream file = File.Open(zipName, FileMode.Create))
                {
                    fileInfos = this.getFilesForCompression(path);
                    
                   

                    using (var archive = new Archive(new ArchiveEntrySettings()))
                    {
                        foreach (FileInfo fileInfo in fileInfos)
                        {
                            fileDeletionList.Add(fileInfo.FullName);
                            archive.CreateEntry(fileInfo.Name, fileInfo);
                        }

                        archive.Save(file);
                    }

                }
                this.Delete(fileDeletionList);
                fileInfos.Clear();
                fileDeletionList.Clear();
            }
            
        }
        public void Delete(List<string> filesForDeletion)
        { 
            foreach (string file in filesForDeletion)
            {
                    File.Delete(file);
            }
        }
        public bool CheckIfThereAreFIlesToCompress(string path)
        {
            bool result = false;
            foreach (string fileName in Directory.GetFiles(path))
            {
                if (File.GetCreationTime(fileName).CompareTo(DateTime.Now) < 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public List<FileInfo> getFilesForCompression(string path)
        {
            List<FileInfo> fileInfosNew = new List<FileInfo>();
                foreach (string fileName in Directory.GetFiles(path))
                {
                    if (File.GetCreationTime(fileName).CompareTo(DateTime.Now) < 0)
                    {
                        FileInfo fileInfo = new FileInfo(fileName);
                        fileInfosNew.Add(fileInfo);
                    }

                }
            return fileInfosNew;
        }
    }
}