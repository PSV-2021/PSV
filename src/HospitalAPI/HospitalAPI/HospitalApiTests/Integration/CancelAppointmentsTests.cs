using Hospital.Schedule.Model;
using Hospital.SharedModel;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace HospitalApiTests.Integration
{
    public class CancelAppointmentsTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql(Constants.ConnectionString);
            context = new MyDbContext(builder.Options);
            //builder.UseInMemoryDatabase("Base");
            //context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Cancel_appointments()
        {
            SetUpDbContext();
            context.Add(new Appointment { Id = 1, PatientId = 1, DoctorId = 1, StartTime = new DateTime(2021, 12, 07, 16, 30, 00), ApointmentDescription = "All good", IsDeleted = false, isCancelled = false });

            CancelAppointmentsController cancelAppointmentsController = new CancelAppointmentsController(context);
            IActionResult retVal = cancelAppointmentsController.CancelAppointment(1);

            retVal.Equals(HttpStatusCode.OK);
        }
    }
}
