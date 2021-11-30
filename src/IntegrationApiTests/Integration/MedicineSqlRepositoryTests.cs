using Hospital.Medicines.Model;
using Hospital.Medicines.Repository.Interfaces;
using Integration.Model;
using Integration.Repository.Interfaces;
using Integration.Service;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Hospital.Medicines.Repository.Sql;
using Hospital.Medicines.Service;
using Xunit;
using Hospital.SharedModel;

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

            Medicine oldVal = repo.GetByName("Brufen");
            int oldAmount = oldVal.Supply;
            service.AddDrugUrgent("Brufen", 10);
            Medicine newVal = repo.GetByName("Brufen");
            newVal.Supply.ShouldBe(oldAmount + 10);

        }
        [Fact]
        public void Adding_nonexisting_drugs_to_repository()
        {
            SetUpDbContext();
            IDrugRepository repo = new DrugSqlRepository(context);
            DrugService service = new DrugService(repo);
            Medicine testMed = repo.GetByName("Brufen");
            repo.Remove(testMed);
            
            service.AddDrugUrgent("Brufen", 10);
            Medicine newVal = repo.GetByName("Brufen");
            newVal.Supply.ShouldBe(10);

        }
    }
}

