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
                WorkingSchedule = new List<WorkingHours>(),
                VacationDays = new List<VacationDays>(),
                AvailableDaysOff = 20,
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 1,
                WorkingHoursId = 1
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
                WorkingSchedule = new List<WorkingHours>(),
                VacationDays = new List<VacationDays>(),
                AvailableDaysOff = 20,
                Id = 2,
                SpecialityId = 2,
                NumberOfPatients = 7,
                WorkingHoursId = 1
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
                WorkingSchedule = new List<WorkingHours>(),
                VacationDays = new List<VacationDays>(),
                AvailableDaysOff = 20,
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 0,
                WorkingHoursId = 1
            });

            context.Add(new Appointment { Id = 1, StartTime = new DateTime(2021, 01, 02), DurationInMunutes = 30, ApointmentDescription = "", IsDeleted = false, DoctorId = 1, PatientId = 1, Canceled = false });
            context.Add(new WorkingHours { Id = 1, BeginningDate = new DateTime(2021, 01, 01), EndDate = new DateTime(2021, 01, 08) });

            RecommendedAppointmentController recommendedAppointmentController = new RecommendedAppointmentController(context);

            IActionResult retVal = recommendedAppointmentController.Get(appointment);

            retVal.Equals(HttpStatusCode.OK);
        }

        public static SearchAppointmentsDTO Create()
        {
            SearchAppointmentsDTO retVal = new SearchAppointmentsDTO { StartInterval = new DateTime(2021, 01, 01), EndInterval = new DateTime(2021, 01, 02), DoctorId = 1, Priority = 1, SpecializationId = 1 };

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
                    WorkingSchedule = new List<WorkingHours>(),
                    VacationDays = new List<VacationDays>(),
                    AvailableDaysOff = 20,
                    Id = 1,
                    SpecialityId = 1,
                    NumberOfPatients = 0,
                    WorkingHoursId = 1
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
                    WorkingSchedule = new List<WorkingHours>(),
                    VacationDays = new List<VacationDays>(),
                    AvailableDaysOff = 20,
                    Id = 1,
                    SpecialityId = 2,
                    NumberOfPatients = 0,
                    WorkingHoursId = 1
            } });
            return retVal;
        }
    }
}
