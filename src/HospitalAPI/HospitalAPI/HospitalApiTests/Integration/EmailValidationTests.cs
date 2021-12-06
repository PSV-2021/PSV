using Hospital.SharedModel;
using Hospital.MedicalRecords.Repository;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.MedicalRecords.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace HospitalApiTests.Integration
{
    public class EmailValidationTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseInMemoryDatabase("Base");
            context = new MyDbContext(builder.Options);
        }
        [Fact] public void ValidateAccount()
        {
            SetUpDbContext();
            EmailValidationController emailValidationController = new EmailValidationController(context);
         //   IActionResult retVal = emailValidationController.Post(GeneratePatientForValidation());

         //   Boolean retValidation = emailValidationController.Get(GeneratePatientForValidation().Token);

         //   retValidation.Equals(true);
        }

        [Fact]
        public void Save_new_patient()
        {
            SetUpDbContext();
            EmailValidationController emailValidationController = new EmailValidationController(context);

         //   IActionResult retVal = emailValidationController.Post(GeneratePatient());

        //    retVal.Equals(HttpStatusCode.OK);
        }


        private Patient GeneratePatient()
        {
            Patient patient = new Patient("Milica", "Marko", "Milic", "1104978805057", new DateTime(1978, 11, 04), Sex.female, "0641664608", "Resavska 5", "mica@gmail.com", null, "n", "n", BloodType.A, false, null, false);
            patient.Id = 2;
            return patient;
        }
        private Patient GeneratePatientForValidation()
        {
            Patient patient = new Patient("Milica", "Marko", "Milic", "1104978805057", new DateTime(1978, 11, 04), Sex.female, "0641664608", "Resavska 5", "mica@gmail.com", null, "n", "n", BloodType.A, false, null, false);
            patient.Id = 3;
            patient.Token = "C1FVPYKHME";
            return patient;
        }
    }
}
