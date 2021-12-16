using Drugstore.Service;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Xunit;

namespace DrugstoreApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class FileCompressionTests
    {
        private FileCompressionService fileCompressionService = new FileCompressionService();
        
        public string CreatePath()
        {
            string current = Directory.GetCurrentDirectory().ToString();
            var gparent = Directory.GetParent(Directory.GetParent(current).ToString()).ToString();
            var path2 = Directory.GetParent(Directory.GetParent(gparent).ToString()).ToString();
            var pathFin = Directory.GetParent(Directory.GetParent(path2).ToString()).ToString();
            return pathFin + @"\Backend\DrugstoreAPI\DrugstoreApiTests\test folder\";
        }
        public void CreateFilesInDirectory()
        {
            string path = this.CreatePath();
            if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
            string path1 = path + "prvifajl.txt";
            using (FileStream fs = File.Create(path1)) ;
            string path2 = path + "drugifajl.txt";
            using (FileStream fs = File.Create(path2)) ;
            string path3 = path + "treci.txt";
            using (FileStream fs = File.Create(path3)) ;
            string path4 = path + "cetvrti.txt";
            using (FileStream fs = File.Create(path4)) ;

        }
        [Fact]
        public void ThereAreFilesToCompress()
        {
            string path = this.CreatePath();
            CreateFilesInDirectory();
           var result = fileCompressionService.CheckIfThereAreFIlesToCompress(path);
            Assert.False(result);
        }
        //[Fact]
        //public void DeleteFiles()
        //{
        //    string path = this.CreatePath();
        //    List<FileInfo> files = Directory.

        //    List<String> fileNames = new List<string>();
        //    foreach(FileInfo fileInfo in files)
        //    {
        //        Console.WriteLine(fileInfo.FullName);
        //        fileNames.Add(fileInfo.FullName);
        //    }
        //    fileCompressionService.Delete(fileNames);
        //    DirectoryInfo dir = new DirectoryInfo(path);
        //    FileInfo[] filesFromDIr = dir.GetFiles();
        //    var result = fileCompressionService.CheckIfThereAreFIlesToCompress(path);
        //    Directory.Delete(path);
        //    Assert.False(result);

        //}

    }
}
