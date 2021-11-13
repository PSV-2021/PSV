using System;
using System.Collections.Generic;
using System.Text;
using Integration.Model;
using Integration.Repository.Sql;
using Integration.Service;
using Integration_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Moq;
using Shouldly;
using Xunit;

namespace IntegrationApiTests.Integration
{
    public class DrugstoresSqlRepositoryTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Theory]
        [MemberData(nameof(Searches))]
        public void Certain_drugs_availability_on_repository(string city, string address, int expectedValue)
        {
            SetUpDbContext();
            IDrugstoreRepository drugstoreSqlRepository = new DrugstoreSqlRepository(context);
            DrugstoreService service = new DrugstoreService(drugstoreSqlRepository);

            List<Drugstore> retVal = service.SearchDrugstoresByCityAndAddress(city, address);

            retVal.Count.ShouldBe(expectedValue);
        }


        public static IEnumerable<object[]> Searches()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Novi Sad", "", 2 });
            retVal.Add(new object[] { "Novi Sad", "Tol", 1 });
            retVal.Add(new object[] { "Kragujevac", "", 0 });
            return retVal;

        }
    }
}
