using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.DTO;
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
        private List<Ingridient> ingridients = new List<Ingridient> { new Ingridient(1, "Aspirin") };
        public void SetUpDbContext()
        {
            

            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql(Constants.ConnectionString);
            context = new MyDbContext(builder.Options);

           // builder.UseInMemoryDatabase("Base");

           // context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Get_medical_record()
        {
            SetUpDbContext();

            context.Add(new Patient(1, "Andjelka", "Andjic", "andji", "andji", "1821099320191", new DateTime(1980, 9, 17), BloodType.A,
                "Milan", Sex.female, "02102019", "Resavska 1", "andja12@gmail.com","0"));
            context.Add(new Patient(2, "Milica", "Andjic", "andji", "andji", "1821099320191", new DateTime(1980, 9, 17), BloodType.A,
                "Milan", Sex.female, "02102019", "Resavska 1", "andja12@gmail.com","0"));

            MedicalrecordController medicalrecordController = new MedicalrecordController(context);
            IActionResult retVal = medicalrecordController.Get("1");
            retVal.Equals(MedicalRecord());

            retVal.Equals(HttpStatusCode.OK);

        }

        public static IEnumerable<object[]> MedicalRecord()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new MedicalRecordDTO
                {
                    Name = "Andjela",
                    Surname = "Andjic",
                    Username = "andji",
                    Password = "andj1",
                    Jmbg = "1821099320191",
                    Date = "17.09.1980.",
                    BType = "A",
                    FathersName = "Milan",
                    Gender = "Female",
                    PhoneNumber = "02102019",
                    Address = "Resavska 1",
                    Email = "andja12@gmail.com"


        } });
            return retVal;
        }
    }
}
