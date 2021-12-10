﻿using Hospital.MedicalRecords.Model;
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
            context.Add(new Appointment { Id = 1, StartTime = new DateTime(2021,11,30,15,30,00), DurationInMunutes = 20, DoctorId = 1, PatientId = 1});
            context.Add(new Doctor
            {
                Name = "Milan",
                Surname = "Popovic",
                Jmbg = "3009998805137",
                DateOfBirth = new DateTime(1998, 04, 20),
                Sex = Sex.male,
                PhoneNumber = "0641664608",
                Adress = "Bulevar Oslobodjenja 4",
                Email = "milan@gmail.com",
                Username = "miki56",
                Password = "02145",
                Type = UserType.doctor,
                SalaryInRsd = 200000,
                WorkingSchedule = new List<WorkingHours>(),
                VacationDays = new List<VacationDays>(),
                AvailableDaysOff = 20,
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 0,
            });
            Patient patient = new Patient { Id = 1, Name = "Andjelka" };
            context.Add(patient);

            ObserveAppointmentsController observeAppointmentsController = new ObserveAppointmentsController(context);
            IActionResult retVal = observeAppointmentsController.Get(patient.Id.ToString());

            retVal.ShouldNotBeNull();
            retVal.Equals(Appointments());
        }
        public static IEnumerable<object[]> Appointments()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Appointment { Id = 1, StartTime = new DateTime(2021, 11, 30, 15, 30, 00), DurationInMunutes = 20, DoctorId = 1, PatientId = 1 } });
            return retVal;
        }

        [Fact]
        public void Get_survey()
        {
            SetUpDbContext();
            context.Add(new Appointment { Id = 1, StartTime = new DateTime(2021, 11, 30, 15, 30, 00), DurationInMunutes = 20, DoctorId = 1, PatientId = 1 });
            Survey survey = new Survey { Id = 1, AppointmentId = 1, PatientId = 1 };
            context.Add(survey);
            Patient patient = new Patient { Id = 1, Name = "Andjelka" };
            context.Add(patient);

            SurveyController surveyController = new SurveyController(context);
            IActionResult retVal = surveyController.Get(survey.PatientId.ToString(), survey.PatientId.ToString());

            retVal.Equals(true);
        }
        public static IEnumerable<object[]> Survey()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Survey { Id = 1,AppointmentId = 1, PatientId = 1 } });
            return retVal;
        }

    }
}
