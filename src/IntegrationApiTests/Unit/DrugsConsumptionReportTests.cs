using Integration_API.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Integration.Model;
using Integration.Service;
using Shouldly;
using Xunit;
using System.IO;

namespace IntegrationApiTests.Unit
{
    public class DrugsConsumptionReportTests
    {
        [Theory]
        [MemberData(nameof(DateRanges))]
        public void Save_drugs_consumption_report(DateTime from, DateTime to, int expectedAmount) 
        {
            DrugsConsumptionReportService service = new DrugsConsumptionReportService();

            int amount = service.SaveDrugsConsumptionReport(new DateRange(from, to));

            Assert.Equal(expectedAmount, amount);
        }

        [Theory]
        [MemberData(nameof(FileNames))]
        public void Upload_drugs_consumption_report(string fileName, bool expectedOutcome)
        {
            DrugsConsumptionReportService service = new DrugsConsumptionReportService();

            bool isUploaded = service.UploadDrugConsumtpionReport(fileName);

            Assert.Equal(expectedOutcome, isUploaded);
        }

        public static IEnumerable<object[]> DateRanges()
        {
            var retVal = new List<object[]>();                                                          //exists from 14.11 to 20.11, 7 each day

            retVal.Add(new object[] { new DateTime(2021, 11, 20), new DateTime(2021, 11, 20), 7 });     //edge case
            retVal.Add(new object[] { new DateTime(2021, 11, 16), new DateTime(2021, 11, 19), 28 });    //in-between case
            retVal.Add(new object[] { new DateTime(2021, 11, 19), new DateTime(2021, 11, 22), 14 });    //from is good, to is OOR
            retVal.Add(new object[] { new DateTime(2021, 11, 12), new DateTime(2021, 11, 14), 7 });     //edge case, from is OOR
            retVal.Add(new object[] { new DateTime(2021, 11, 10), new DateTime(2021, 11, 13), 0 });     //should be 0, not data for this date range
            retVal.Add(new object[] { new DateTime(2021, 11, 17), new DateTime(2021, 11, 15), 0 });     //should be 0, first date is after the second one
            retVal.Add(new object[] { null, null, 0 });                 
            retVal.Add(new object[] { null, new DateTime(2021, 11, 18), 35 });
            retVal.Add(new object[] { new DateTime(2021, 11, 19), null, 0 });

            return retVal;
        }

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Izvestaj o potrosnji lekova.pdf" , true});
            retVal.Add(new object[] { "Izvestaj.pdf", false });

            return retVal;
        }
    }
}


