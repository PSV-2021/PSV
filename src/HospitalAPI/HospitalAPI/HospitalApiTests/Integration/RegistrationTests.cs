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
    [Trait("Type", "IntegrationTest")]
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
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 1, Sex.male));
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 2, 1, 5, Sex.male));
            DoctorsController doctorController = new DoctorsController(context);
            IActionResult retVal = doctorController.Get();

            retVal.Equals(Doctors());
        }

        [Fact]
        public void Get_doctors()
        {
            SetUpDbContext();
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 21, 1, 0, Sex.male));

            DoctorsController doctorsController = new DoctorsController(context);
            IActionResult retVal = doctorsController.Get();

            retVal.Equals(Doctors());
        }
        public static IEnumerable<object[]> Doctors()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 21, 1, 0, Sex.male)
         });
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
            context.Add(new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 21, 1, 0, Sex.male));

            PatientRegistrationController patientRegistrationController = new PatientRegistrationController(context);
            IActionResult retVal = patientRegistrationController.Post(GeneratePatient());

            retVal.Equals(HttpStatusCode.OK);
        }

        private PatientDto GeneratePatient()
        {
            return new PatientDto { Name = "Mirko", FathersName = "Srdjan", Surname = "Kitic", Jmbg = "3009998805057", Date = "20/01/2000 00:00:00", Sex = Sex.male, PhoneNumber = "0641664608", Address = "Resavska 5", Email = "mirko@gmail.com", Username = "uproba", Password = "pproba", BloodType = BloodType.A, DoctorId = 21, Allergens = new List<String>() };
        }
    }
}

