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
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 1
            });
            context.Add(new Doctor
            {
                Name = "Rade",
                Surname = "Radic",
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
                Id = 2,
                SpecialityId = 2,
                NumberOfPatients = 7
            });

            DoctorsController doctorController = new DoctorsController(context);
            IActionResult retVal = doctorController.Get();

            retVal.Equals(Doctors());
        }

        [Fact]
        public void Get_available_appointment_by_doctor_priority()
        {
            SetUpDbContext();

            var appointment = Create();
          
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
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 0
            });

            context.Add(new Appointment { Id = 1, StartTime = new DateTime(2021, 01, 02), DurationInMunutes = 30, ApointmentDescription = "", IsDeleted = false, DoctorId = 1, PatientId = 1, isCancelled = false });

            RecommendedAppointmentController recommendedAppointmentController = new RecommendedAppointmentController(context);

            IActionResult retVal = recommendedAppointmentController.Post(appointment);

            retVal.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Schedule_appointment()
        {
            SetUpDbContext();

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
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 0
            });

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
            retVal.Add(new object[] { new Doctor
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
                    Id = 1,
                    SpecialityId = 1,
                    NumberOfPatients = 0
            } });
            retVal.Add(new object[] { new Doctor
                {
                    Name = "Rade",
                    Surname = "Radic",
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
                    Id = 1,
                    SpecialityId = 2,
                    NumberOfPatients = 0
            } });
            return retVal;
        }

        [Fact]
        public void Get_available_appointment_by_date_priority()
        {
            SetUpDbContext();

            var appointment = Create();

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
                Id = 4,
                SpecialityId = 1,
                NumberOfPatients = 0
            });

            context.Add(new Appointment { Id = 4, StartTime = new DateTime(2021, 12, 12, 8, 30,0), DurationInMunutes = 30, ApointmentDescription = "", IsDeleted = false, DoctorId = 1, PatientId = 1, isCancelled = false });
          
            RecommendedAppointmentController recommendedAppointmentController = new RecommendedAppointmentController(context);

            IActionResult retVal = recommendedAppointmentController.Post(appointment);

            retVal.Equals(HttpStatusCode.OK);
            retVal.Equals(Appointments());

        }
        public static IEnumerable<object[]> Appointments()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[]
            {   new Appointment { StartTime = new DateTime(2021, 12, 12, 8, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 9, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 9, 30, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 10, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 10, 30, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 11, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 11, 30, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 12, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 12, 30, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 13, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 13, 30, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 14, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 15, 00, 00) },
                new Appointment { StartTime = new DateTime(2021, 12, 12, 15, 30, 00) },
            });

            return retVal;
        }
    }
}
