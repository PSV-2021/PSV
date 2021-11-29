using Integration.Model;
using Integration.Repository.Interfaces;
using Integration.Service;
using Integration.Sql;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationApiTests.Integration
{
    public class MedicineSqlRepositoryTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }
        [Fact]
        public void Adding_existing_drugs_to_repository()
        {
            SetUpDbContext();
            IDrugRepository repo = new DrugSqlRepository(context);
            DrugService service = new DrugService(repo);

            Drug oldVal = repo.GetByName("Brufen");
            int oldAmount = oldVal.Supply;
            service.AddDrugUrgent("Brufen", 10);
            Drug newVal = repo.GetByName("Brufen");
            newVal.Supply.ShouldBe(oldAmount + 10);

        }
        [Fact]
        public void Adding_nonexisting_drugs_to_repository()
        {
            SetUpDbContext();
            IDrugRepository repo = new DrugSqlRepository(context);
            DrugService service = new DrugService(repo);
            Drug testMed = repo.GetByName("Brufen");
            repo.Remove(testMed);
            
            service.AddDrugUrgent("Brufen", 10);
            Drug newVal = repo.GetByName("Brufen");
            newVal.Supply.ShouldBe(10);

        }
    }
}

