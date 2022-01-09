using Hospital.Schedule.Model;
using Hospital.SharedModel;
using HospitalAPI.Controllers;
using HospitalAPI.DTO;
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
            retVal.ShouldNotBeNull();
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

            retVal.Equals(true);
        }

        private Appointment GenerateAppointment()
        {
            return new Appointment(new DateTime(2021, 05, 30), 30, "", false, 1, 1, false, true);
        }

        [Fact]
        public void Get_doctors_by_specialty()
        {
            SetUpDbContext();
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 2, 1, Sex.male));
            context.Add(new Doctor("Ljubica", "Markovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 2, 1, 5, Sex.female));

            DoctorsController doctorController = new DoctorsController(context);
            IActionResult retVal = doctorController.GetDoctorsBySpecialty("2");

            retVal.ShouldNotBeNull();
            retVal.Equals(Doctors());
        }
        public static IEnumerable<object[]> Doctors()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[]
            {
                new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 2, 1, Sex.male)
            });
            return retVal;
        }


        [Fact]
        public void Get_appointments_by_doctor_and_date()
        {
            SetUpDbContext();
            context.Add(new Appointment(2, new DateTime(2021, 12, 12, 14, 30, 00), 30, "", false, 1, 1, false));
            context.Add(new Appointment(3, new DateTime(2021, 12, 12, 8, 30, 00), 30, "", false, 1, 1, false));
            
            StandardAppointmentController standardAppointmentController = new StandardAppointmentController(context);
            IActionResult retVal = standardAppointmentController.GetFreeAppointments("1","12.12.2021");

            retVal.ShouldNotBeNull();
            retVal.Equals(Appointments());
        }

        public static IEnumerable<object[]> Appointments()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[]
            {   new Appointment(new DateTime(2021, 12, 12, 8, 30, 00), 30, "", false, 1, 1, false, true),
                new Appointment(new DateTime(2021, 12, 12, 9, 00, 00), 30, "", false, 1, 1, false, true),
                new Appointment(new DateTime(2021, 12, 12, 10, 00, 00), 30, "", false, 1, 1, false, true),
                new Appointment(new DateTime(2021, 12, 12, 14, 30, 00), 30, "", false, 1, 1, false, true)
            }); 
            return retVal;
        }
        [Fact]
        public void Schedule_appointment()
        {
            SetUpDbContext();
            var appointment = GenerateAppointmentDTO();
            StandardAppointmentController surveyController = new StandardAppointmentController(context);
            IActionResult retVal = surveyController.Schedule(appointment);
            retVal.Equals(HttpStatusCode.OK);
        }
        private AppointmentDTO GenerateAppointmentDTO()
        {
            return new AppointmentDTO { StartTime = "20/01/2000 09:00:00", DoctorId = "1", PatientId = "1" };
        }



    }
}

