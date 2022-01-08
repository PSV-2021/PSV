using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Model;
using Hospital.SharedModel;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class ObserveAppointmentsTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            //builder.UseNpgsql(Constants.ConnectionString);
            //context = new MyDbContext(builder.Options);
            builder.UseInMemoryDatabase("Base");
            context = new MyDbContext(builder.Options);
        }
        [Fact]
        public void Get_appointments()
        {
            SetUpDbContext();
            context.Add(new Appointment( 1, new DateTime(2021,11,30,15,30,00), 20, 1, 1));
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 0, Sex.male));
            Patient patient = new Patient(1, "Andjelka", "Andjic", "andji", "andji", "1821099320191", new DateTime(1980, 9, 17), BloodType.A,
                "Milan", Sex.female, "02102019", "Resavska 1", "andja12@gmail.com","0");
            context.Add(patient);

            ObserveAppointmentsController observeAppointmentsController = new ObserveAppointmentsController(context);
            IActionResult retVal = observeAppointmentsController.Get(patient.Id.ToString());

            retVal.ShouldNotBeNull();
            retVal.Equals(Appointments());
        }
        public static IEnumerable<object[]> Appointments()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Appointment (1, new DateTime(2021, 11, 30, 15, 30, 00), 20, 1, 1 ) });
            return retVal;
        }

       
    }
}
