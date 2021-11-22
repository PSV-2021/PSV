using Moq;
using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using System.IO;
using Drugstore.Service;

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

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Brufen - specifikacija.pdf", true });
            retVal.Add(new object[] { "Panadol - specifikacija.pdf", false });

            return retVal;
        }
    }
}


