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
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Theory]
        [MemberData(nameof(DateRanges))]
        public void Save_drugs_consumption_report(DateTime from, DateTime to, int expectedAmount) 
        {
            SetUpDbContext();
            DrugsConsumptionReportService service = new DrugsConsumptionReportService(context);

            int amount = service.SaveDrugsConsumptionReport(new DateRange(from, to));

            Assert.Equal(expectedAmount, amount);
        }

        [Theory]
        [MemberData(nameof(FileNames))]
        public void Upload_drugs_consumption_report(string fileName, bool expectedOutcome)
        {
            SetUpDbContext();
            DrugsConsumptionReportService service = new DrugsConsumptionReportService(context);

            bool isUploaded = service.UploadDrugConsumptionReport(fileName);

            Assert.Equal(expectedOutcome, isUploaded);
        }

        [Fact]
        public void Exception_for_Rebex_off_Upload()
        {
            SetUpDbContext();
            DrugsConsumptionReportService service = new DrugsConsumptionReportService(context);

            bool result = service.UploadDrugConsumptionReport("Izvestaj o potrosnji lekova 14.11.2021. - 15.11.2021..pdf");

            Assert.True(result);
        }

        public static IEnumerable<object[]> DateRanges()
        {
            var retVal = new List<object[]>();                                                          //exists from 14.11 to 20.11, 7 each day

            retVal.Add(new object[] { new DateTime(2021, 11, 20), new DateTime(2021, 11, 20), 7 });     //edge case
            retVal.Add(new object[] { new DateTime(2021, 11, 12), new DateTime(2021, 11, 14), 7 });     //edge case, from is OOR
            retVal.Add(new object[] { new DateTime(2021, 11, 10), new DateTime(2021, 11, 13), 0 });     //should be 0, not data for this date range
            retVal.Add(new object[] { new DateTime(2021, 11, 17), new DateTime(2021, 11, 15), 0 });     //should be 0, first date is after the second one
            retVal.Add(new object[] { null, null, 0 });                 
            retVal.Add(new object[] { null, new DateTime(2021, 11, 18), 7 });
            retVal.Add(new object[] { new DateTime(2021, 11, 19), null, 0 });

            return retVal;
        }

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Izvestaj o potrosnji lekova 14.11.2021. - 15.11.2021..pdf", true});
            retVal.Add(new object[] { "Izvestaj.pdf", false });

            return retVal;
        }
    }
}


