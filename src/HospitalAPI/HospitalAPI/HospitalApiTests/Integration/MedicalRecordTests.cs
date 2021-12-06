using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;
using HospitalAPI;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace HospitalApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class MedicalRecordTests
    {
        private MyDbContext context;

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseInMemoryDatabase("Base");

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Get_medical_record()
        {
            SetUpDbContext();

            Patient patient1 = new Patient { Id = 1, Name = "Andjelka" };
            Patient patient2 = new Patient { Id = 2, Name = "Milica" };
            context.AddRange(patient1, patient2);

            MedicalrecordController medicalrecordController = new MedicalrecordController(context);
            IActionResult retVal = medicalrecordController.Get(patient1.Id.ToString());

            retVal.Equals(HttpStatusCode.OK);

        }
    }
}
