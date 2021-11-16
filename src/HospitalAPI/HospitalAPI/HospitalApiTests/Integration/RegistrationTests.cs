using Hospital.Model;
using Hospital.Repository;
using Microsoft.EntityFrameworkCore;
using Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace HospitalApiTests.Integration
{
    public class RegistrationTests
    {
        private readonly string communicationLink = "http://localhost:5000";
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Theory]
        [MemberData(nameof(Doctors))]
        public void Get_doctors(Doctor doctor, bool expectedValue)
        {
            SetUpDbContext();
            DoctorSqlRepository doctorSqlRepository = new DoctorSqlRepository(context);

            List<Doctor> retVal = doctorSqlRepository.GetAll();

            retVal.Equals(doctor).ShouldBe(expectedValue);
        }
        public static IEnumerable<object[]> Doctors()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), Sex.male, "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com", "01", 20000, null, "miki56", "02145"), true });
            retVal.Add(new object[] { null, true });
            return retVal;
        }
        [Fact]
        public void Get_allergens()
        {
            SetUpDbContext();
            IngredientSqlRepository ingredientSqlRepository = new IngredientSqlRepository(context);

            List<Ingridient> retVal = ingredientSqlRepository.GetAll();

            retVal.Equals(Ingridients());
        }
        public static IEnumerable<object[]> Ingridients()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Ingridient("Panclav")});
            retVal.Add(new object[] { new Ingridient("Penicilin") });
            return retVal;
        }
        /* [Theory]
         [MemberData(nameof(ExpectedStatus))]
         public async void Get_all_doctors(HttpStatusCode expectedStatusCode)
         {
             HttpClient client = CreateClient();
             HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/");
             response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
         }
         public static IEnumerable<object[]> ExpectedStatus =>
                new List<object[]>
                {
                 new object[] {HttpStatusCode.OK},
                 new object[] {HttpStatusCode.BadRequest}
                };*/
    }
}

