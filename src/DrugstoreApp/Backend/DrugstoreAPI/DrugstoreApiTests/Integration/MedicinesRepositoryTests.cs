using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shouldly;
using Xunit;

namespace DrugstoreApiTests.Integration
{
    public class MedicinesRepositoryTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void get_test_medicine()
        {
             SetUpDbContext();

             MedicineSqlRepository medicineSqlRepository = new MedicineSqlRepository(context);

             Medicine retVal = medicineSqlRepository.GetByName("Test1");

             retVal.Name.ShouldBe("Test1");
        }

        [Theory]
        [MemberData(nameof(Medicines))]
        public void Certain_drugs_availability_on_repository(Medicine drug, bool expectedValue)
        {
            SetUpDbContext();
            MedicineSqlRepository medicineSqlRepository = new MedicineSqlRepository(context);
            MedicineService service = new MedicineService(medicineSqlRepository);

            bool retVal = service.CheckForAmountOfDrug(drug.Name, drug.Supply);

            retVal.ShouldBe(expectedValue);
        }

        public static IEnumerable<object[]> Medicines()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Medicine(5, "Test1", 500, 5), true });
            retVal.Add(new object[] { new Medicine(6, "Test2", 500, 30), false });
            retVal.Add(new object[] { new Medicine(7, "Test3", 500, 10), false });
            return retVal;

        }

    }
}
