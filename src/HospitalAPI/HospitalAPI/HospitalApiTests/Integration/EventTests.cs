using Hospital.PatientEvent.Model;
using Hospital.SharedModel;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;


namespace HospitalApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class EventTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql(Constants.ConnectionString);
            context = new MyDbContext(builder.Options);
        }
        [Fact]
        public void GetSucceedQuitRatio()
        {
            SetUpDbContext();
            context.Add(new Event(1, "1", new DateTime(2022, 01, 22)));
            context.Add(new Event(2, "3", new DateTime(2022, 01, 23)));
            context.Add(new Event(3, "4", new DateTime(2022, 01, 22)));
            context.Add(new Event(4, "7", new DateTime(2022, 01, 22)));
            context.Add(new Event(5, "7", new DateTime(2022, 01, 23)));
            context.Add(new Event(6, "2", new DateTime(2022, 01, 23)));

            EventController eventController = new EventController(context);
            IActionResult retVal = eventController.GetSucceedQuitRatio();

            retVal.Equals(HttpStatusCode.OK);
            retVal.Equals(new List<double> {(double)1/(double)6, (double)1/(double)6, (double)1/(double)3, (double)5/(double)6 });

        }
        [Fact]
        public void GetDailyNumberOfScheduling()
        {
            SetUpDbContext();
            context.Add(new Event(1, "1", new DateTime(2022, 01, 22)));
            context.Add(new Event(2, "3", new DateTime(2022, 01, 23)));
            context.Add(new Event(3, "4", new DateTime(2022, 01, 22)));
            context.Add(new Event(4, "7", new DateTime(2022, 01, 22)));
            context.Add(new Event(5, "7", new DateTime(2022, 01, 23)));
            context.Add(new Event(6, "2", new DateTime(2022, 01, 23)));

            EventController eventController = new EventController(context);
            IActionResult retVal = eventController.GetDailyNumberOfScheduling();

            retVal.Equals(HttpStatusCode.OK);
            retVal.Equals(new List<int> { 1,0,0});

        }
    }
}
