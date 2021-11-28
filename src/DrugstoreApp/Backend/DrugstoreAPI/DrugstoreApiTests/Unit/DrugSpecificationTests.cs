using Moq;
using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using System.IO;
using Drugstore.Service;
using System.Net.Sockets;

namespace DrugstoreApiTests.Unit
{
    public class DrugSpecificationTests
    {
        [Theory]
        [MemberData(nameof(FileNames))]
        public void Upload_drugs_consumption_report(string fileName, bool expectedOutcome)
        {
            DrugSpecificationService service = new DrugSpecificationService();

            bool isUploaded = service.UploadDrugSpecification(fileName);

            Assert.Equal(expectedOutcome, isUploaded);
        }

        [Fact]
        public void Exception_for_Rebex_off_Upload()
        {
            DrugSpecificationService service = new DrugSpecificationService();

            bool result = service.UploadDrugSpecification("Brufen");

            Assert.False(result);
        }

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Brufen", true });
            retVal.Add(new object[] { "Panadol", false });

            return retVal;
        }
    }
}


