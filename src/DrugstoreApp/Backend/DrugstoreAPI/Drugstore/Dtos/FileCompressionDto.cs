using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Models
{
    public class FileCompressionDto
    {
        public string FileName { get; set; }
        public FileInfo FileInfo { get; set; }


        public FileCompressionDto(string fileName, FileInfo fileInfo)
        {
            this.FileName = fileName;
            this.FileInfo = fileInfo;


        }

        public FileCompressionDto()
        {
        }
    }
}