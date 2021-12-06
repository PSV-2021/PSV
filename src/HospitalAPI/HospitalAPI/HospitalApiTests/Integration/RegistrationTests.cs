using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;
using HospitalAPI.DTO;
using Xunit;

namespace HospitalApiTests.Integration
{
    public class RegistrationTests
    {
        //private readonly string communicationLink = "http://localhost:5000";
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
        public void Get_avalible_general_doctors()
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
                NumberOfPatients = 1
            });
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
                Id = 2,
                SpecialityId = 1,
                NumberOfPatients = 5
            });
            DoctorsController doctorController = new DoctorsController(context);
            IActionResult retVal = doctorController.Get();

            retVal.Equals(Doctors());
        }

        [Fact]
        public void Get_doctors()
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
                NumberOfPatients = 0
            });

            DoctorsController doctorsController = new DoctorsController(context);
            IActionResult retVal = doctorsController.Get();

            retVal.Equals(Doctors());
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
                    NumberOfPatients = 0
            } });
            return retVal;
        }
        [Fact]
        public void Get_allergens()
        {
            SetUpDbContext();
            context.Add(new Ingridient(1, "Panclav"));
            context.Add(new Ingridient(2, "Penicilin"));
            context.Add(new Ingridient(3, "Panadol"));

            IngredientsController ingredientsController = new IngredientsController(context);
            IActionResult retVal = ingredientsController.Get();

            retVal.Equals(Ingridients());
        }
        public static IEnumerable<object[]> Ingridients()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Ingridient(1, "Panclav") });
            retVal.Add(new object[] { new Ingridient(2, "Penicilin") });
            retVal.Add(new object[] { new Ingridient(3, "Panadol") });
            return retVal;
        }
        [Fact]
        public void Save_patient()
        {
            SetUpDbContext();
            context.Add(new Doctor
            {
                Id = 1,
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
                SpecialityId = 1,
                NumberOfPatients = 0
            });

            PatientRegistrationController patientRegistrationController = new PatientRegistrationController(context);
            IActionResult retVal = patientRegistrationController.Post(GeneratePatient());

            retVal.Equals(HttpStatusCode.OK);
        }

        private PatientDto GeneratePatient()
        {
            return new PatientDto { Name = "Mirko", FathersName = "Srdjan", Surname = "Kitic", Jmbg = "3009998805057", Date = "20/01/2000 00:00:00", Sex = Sex.male, PhoneNumber = "0641664608", Address = "Resavska 5", Email = "mirko@gmail.com", Username = "uproba", Password = "pproba", BloodType = BloodType.A, DoctorId = 1, Allergens = new List<String>() };
        }
    }
}

