using Hospital.Schedule.Model;
using Hospital.SharedModel;
using HospitalAPI.Controllers;
using Hospital.DTO;
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
    public class RecommendedAppointmentTests
    {
        private MyDbContext context;

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseInMemoryDatabase("Base");

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Get_all_doctors()
        {
            SetUpDbContext();
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 1, Sex.male));
            context.Add(new Doctor("Rade", "Radic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 2, 2, 7, Sex.male));
            
            DoctorsController doctorController = new DoctorsController(context);
            IActionResult retVal = doctorController.Get();

            retVal.Equals(Doctors());
        }

        [Fact]
        public void Get_available_appointment_by_doctor_priority()
        {
            SetUpDbContext();

            var appointment = Create();

            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 0, Sex.male));

            context.Add(new Appointment ( 1, new DateTime(2021, 01, 02), 30, "", false, 1,  1,  false ));

            RecommendedAppointmentController recommendedAppointmentController = new RecommendedAppointmentController(context);

            IActionResult retVal = recommendedAppointmentController.Post(appointment);

            retVal.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Schedule_appointment()
        {
            SetUpDbContext();

            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 0, Sex.male));

            RecommendedAppointmentController recommendedAppointmentController = new RecommendedAppointmentController(context);

            IActionResult retVal = recommendedAppointmentController.Schedule(new ScheduleDTO { Start = new DateTime(2021, 12, 15, 8, 0, 0), Id = 1 });

            retVal.Equals(HttpStatusCode.OK);
        }

        public static SearchAppointmentsDTO Create()
        {
            SearchAppointmentsDTO retVal = new SearchAppointmentsDTO { StartInterval = "12/12/2021", EndInterval = "12/14/2021", DoctorId = 1, Priority = 1, SpecializationId = 1 };

            return retVal;
        }

        public static IEnumerable<object[]> Doctors()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] {new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 0, Sex.male) });
            retVal.Add(new object[] {new Doctor("Rade", "Radic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 2, 2, 0, Sex.male) });

            return retVal;
        }

        [Fact]
        public void Get_available_appointment_by_date_priority()
        {
            SetUpDbContext();

            var appointment = Create();

            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 4, 1, 0, Sex.male));

            context.Add(new Appointment( 4,new DateTime(2021, 12, 12, 8, 30,0), 30, "", false, 1, 1, false ));
          
            RecommendedAppointmentController recommendedAppointmentController = new RecommendedAppointmentController(context);

            IActionResult retVal = recommendedAppointmentController.Post(appointment);

            retVal.Equals(HttpStatusCode.OK);
            retVal.Equals(Appointments());

        }
        public static IEnumerable<object[]> Appointments()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[]
            {   new Appointment(new DateTime(2021, 12, 12, 8, 30, 00), 30, "", false, 1, 1, false),
                new Appointment(new DateTime(2021, 12, 12, 9, 00, 00), 30, "", false, 1, 1, false),
                new Appointment(new DateTime(2021, 12, 12, 10, 00, 00), 30, "", false, 1, 1, false),
                new Appointment(new DateTime(2021, 12, 12, 14, 30, 00), 30, "", false, 1, 1, false)
            });

            return retVal;
        }
    }
}
