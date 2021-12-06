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
using DrugstoreAPI.Models;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Timers;

namespace Drugstore.Service
{
    public class FileCompressionService 
    {

        private List<FileCompressionDto> fileInfos = new List<FileCompressionDto>();
        private List<string> fileDeletionList = new List<string>();

        public  void CompressOldFiles()
        {
            string zipName = @"\rebex\data\public\Compressed Drugstore files\Kompersovano-" + DateTime.Now.Day.ToString() + "." +
                DateTime.Now.Month.ToString()
                + "." + DateTime.Now.Year.ToString()
                + ". " + DateTime.Now.Hour.ToString()
                + " i " + DateTime.Now.Minute.ToString()
                + ".zip";

            if (this.CheckIfThereAreFIlesToCompress(@"\rebex\data\public\Drugstore files\"))
            {
                using (FileStream file = File.Open(zipName, FileMode.Create))
                {
                    foreach (string fileName in Directory.GetFiles(@"\rebex\data\public\Drugstore files\"))
                    {
                        if (File.GetCreationTime(fileName).CompareTo(DateTime.Now) < 0)
                        {
                            FileInfo fileInfo = new FileInfo(fileName);
                            string uniqueFileName = fileInfo.Name;
                            FileCompressionDto fileCompressed = new FileCompressionDto(uniqueFileName, fileInfo);
                            fileInfos.Add(fileCompressed);
                            fileDeletionList.Add(fileName);

                        }
                    }

                    using (var archive = new Archive(new ArchiveEntrySettings()))
                    {
                        foreach (FileCompressionDto fileInfo in fileInfos)
                        {
                            archive.CreateEntry(fileInfo.FileName, fileInfo.FileInfo);
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
            foreach (string fileName in Directory.GetFiles(path))
            {
                if (File.GetCreationTime(fileName).CompareTo(DateTime.Now) < 0)
                {
                    return true;
                }
            }
            return false;
        }

 
    }
}
