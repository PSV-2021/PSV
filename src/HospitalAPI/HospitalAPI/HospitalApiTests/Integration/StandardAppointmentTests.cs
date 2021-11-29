using Hospital.Schedule.Model;
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
    public class StandardAppointmentTests
    {
        private MyDbContext context;

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseInMemoryDatabase("Base");

            context = new MyDbContext(builder.Options);
        }
        [Fact]
        public void Get_specialties()
        {
            SetUpDbContext();
            context.Add(new Speciality(1, "general"));
            context.Add(new Speciality(2, "cardiology"));

            SpecialtyController specialtyController = new SpecialtyController(context);
            IActionResult retVal = specialtyController.Get();

            retVal.Equals(Specialties());
        }
        public static IEnumerable<object[]> Specialties()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Speciality(1, "general") });
            retVal.Add(new object[] { new Speciality(2, "cardiology") });
            return retVal;
        }
        [Fact]
        public void Save_appointment()
        {
            SetUpDbContext();
           
            StandardAppointmentController standardAppointmentController = new StandardAppointmentController(context);
            IActionResult retVal = standardAppointmentController.Post(GenerateAppointment());

            retVal.Equals(HttpStatusCode.OK);
        }

        private Appointment GenerateAppointment()
        {
            return new Appointment { };
        }
    }
}

