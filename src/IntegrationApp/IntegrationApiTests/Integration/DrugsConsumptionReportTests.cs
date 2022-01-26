using Integration_API.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Integration.Model;
using Integration.Service;
using Shouldly;
using Xunit;
using System.IO;
using System.Net.Sockets;
using Model.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace IntegrationApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]

    public class DrugsConsumptionReportTests
    {
        private MyDbContext context;
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString());

            context = new MyDbContext(builder.Options);
        }

        [SkippableTheory]
        [MemberData(nameof(FileNames))]
        public void Upload_drugs_consumption_report(string fileName, bool expectedOutcome)
        {
            Skip.If(skippable);
            SetUpDbContext();
            DrugsConsumptionReportService service = new DrugsConsumptionReportService(context);

            bool isUploaded = service.UploadDrugConsumptionReport(fileName);

            Assert.Equal(expectedOutcome, isUploaded);
        }

        [SkippableFact]
        public void Exception_for_Rebex_off_Upload()
        {
            Skip.If(skippable);
            SetUpDbContext();
            DrugsConsumptionReportService service = new DrugsConsumptionReportService(context);

            bool result = service.UploadDrugConsumptionReport("Izvestaj o potrosnji lekova 15.11.2021. - 19.11.2021..pdf");

            Assert.True(result);
        }

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Izvestaj o potrosnji lekova 15.11.2021. - 19.11.2021..pdf", true});
            retVal.Add(new object[] { "Izvestaj o potrosnji lekova 16.11.2021. - 18.11.2021..pdf", true });

            return retVal;
        }
    }
}


