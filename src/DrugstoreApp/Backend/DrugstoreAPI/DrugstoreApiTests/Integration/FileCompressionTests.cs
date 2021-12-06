using Drugstore.Service;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Xunit;

namespace DrugstoreApiTests.Unit
{
    [Trait("Type", "IntegrationTest")]
    public class FileCompressionTests
    {
        private string directoryPath = @"\PSV\src\DrugstoreApp\Backend\DrugstoreAPI\DrugstoreApiTests\test folder\";
        private FileCompressionService fileCompressionService = new FileCompressionService();
        public void CreateFilesInDirectory()
        {
            string path1 = directoryPath + "prvifajl.txt";
            using (FileStream fs = File.Create(path1)) ;
            string path2 = directoryPath + "drugifajl.txt";
            using (FileStream fs = File.Create(path2)) ;
            string path3 = directoryPath + "treci.txt";
            using (FileStream fs = File.Create(path3)) ;
            string path4 = directoryPath + "cetvrti.txt";
            using (FileStream fs = File.Create(path4)) ;

        }
        [Fact]
        public void ThereAreFilesToCompress()
        {
            CreateFilesInDirectory();
           var result = fileCompressionService.CheckIfThereAreFIlesToCompress(directoryPath);
            Assert.True(result);
        }
        [Fact]
        public void DeleteFiles()
        {
            List<FileInfo> files = fileCompressionService.getFilesForCompression(directoryPath);

            List<String> fileNames = new List<string>();
            foreach(FileInfo fileInfo in files)
            {
                Console.WriteLine(fileInfo.FullName);
                fileNames.Add(fileInfo.FullName);
            }
            fileCompressionService.Delete(fileNames);
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            FileInfo[] filesFromDIr = dir.GetFiles();
            var result = fileCompressionService.CheckIfThereAreFIlesToCompress(directoryPath);
            Assert.False(result);

        }

    }
}
