using Drugstore.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Drugstore.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Medicine> Medicines
        {
            get; set;
        }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DrugstoreOffer> DrugstoreOffers { get; set; }
        public DbSet<DrugSpecification> DrugSpecifications { get; set; }
        public DbSet<DrugTender> DrugTenders { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine(1, "Brufen", 150, 150, "bla", "bla", "bla", "bla", null, 100.00, "bla", "bla"),
                new Medicine(2, "Paracetamol", 150, 10, "bla", "bla", "bla", "bla", null, 100.00, "bla", "bla"),
                new Medicine(3, "Palitreks", 150, 30, "bla", "bla", "bla", "bla", null, 100.00, "bla", "bla")
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback("Health", "aaa", "Lenka vrati zeton", ""),
                new Feedback("Ime bolnice 223", "bbb", "normalno", ""),
                new Feedback("Ime bolnice 224", "ccc", "bla bla", "")

            );

            modelBuilder.Entity<Hospital>().HasData(
                new Hospital("Health", 1, "http://localhost:5000", "DrugStoreSecretKey")

            );

            modelBuilder.Entity<Pharmacist>().HasData(
                new Pharmacist(1, "farmaceut", "farmaceut", "Farmaceut")
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer(5, "kupac", "kupac", "Kupac", "Adresa kupca 123")
            ) ;
            
            modelBuilder.Entity<DrugstoreOffer>().HasData(
                new DrugstoreOffer("1", "Content", "title", DateTime.Now, DateTime.Now,"Apotekica")
            );

            modelBuilder.Entity<DrugSpecification>().HasData(
               new DrugSpecification("Brufen", "Ovde ide tekst specifikacije za Brufen"),
               new DrugSpecification("Paracetamol", "Ovde ide tekst specifikacije za Paracetamol"),
               new DrugSpecification("Palitreks", "Ovde ide tekst specifikacije za Palitreks")
           );
            modelBuilder.Entity<DrugTender>().HasData(
                new DrugTender("as", DateTime.Now.AddDays(-7), "Brufen - 150, Palitreks - 100, Andol - 40", true),
                new DrugTender("2", DateTime.Now.AddDays(21), "Brufen - 120, Palitreks - 90, Andol - 50", false)
            );

            modelBuilder.Entity<TenderOffer>().HasData(
                new TenderOffer("1", "Brufen - 100, Palitreks - 80, Andol - 40", 5000, "as", false, 1, true),
                new TenderOffer("2", "Brufen - 120, Palitreks - 50, Andol - 35", 5900, "2", false, 2, true)
            );
        }
    }
}
