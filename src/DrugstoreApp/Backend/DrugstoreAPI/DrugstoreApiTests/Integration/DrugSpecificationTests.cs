using Moq;
using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using System.IO;
using Drugstore.Service;
using System.Net.Sockets;
using Drugstore.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugstoreApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]

    public class DrugSpecificationTests
    {

        private MyDbContext context;
        private void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString());

            context = new MyDbContext(builder.Options);
        }

        [Theory]
        [MemberData(nameof(FileNames))]
        public void Upload_drugs_consumption_report(string fileName, bool expectedOutcome)
        {
            DrugSpecificationService service = new DrugSpecificationService(context);

            bool isUploaded = service.UploadDrugSpecification(fileName);

            Assert.Equal(expectedOutcome, isUploaded);
        }

        [Fact]
        public void Exception_for_Rebex_off_Upload()
        {
            DrugSpecificationService service = new DrugSpecificationService(context);

            bool result = service.UploadDrugSpecification("Brufen");

            Assert.True(result);
        }

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Brufen", true });
            retVal.Add(new object[] { "Palitreks", true });

            return retVal;
        }
    }
}


