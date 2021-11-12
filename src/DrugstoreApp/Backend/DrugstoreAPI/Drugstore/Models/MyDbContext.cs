using Drugstore.Models;
using Microsoft.EntityFrameworkCore;


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

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Brufen", Price = 250.00 },
                new Medicine { Id = 2, Name = "Olynth", Price = 180.00 },
                new Medicine { Id = 3, Name = "Polinol", Price = 670.00 }
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback("Ime bolnice 222", "aaa", "Lenka vrati zeton", ""),
                new Feedback("Ime bolnice 223", "bbb", "normalno", ""),
                new Feedback("Ime bolnice 224", "ccc", "bla bla", "")

            );

            modelBuilder.Entity<Hospital>().HasData(
                new Hospital("Ime bolnice 222", 1, "localhost:5000", "DrugStoreSecretKey")

            );
        }
    }
}
