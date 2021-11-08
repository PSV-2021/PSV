using DrugstoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Integration.Model;
//using Integration_API.Model;
//using Microsoft.EntityFrameworkCore;

namespace Model.DataBaseContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback("Ime bolnice 222", "aaa", "Lenka vrati zeton", ""),
                new Feedback("Ime bolnice 223", "bbb", "normalno", ""),
                new Feedback("Ime bolnice 224", "ccc", "bla bla", "")

            );


            modelBuilder.Entity<Hospital>().HasData(
                new Hospital("Ime bolnice 222", 1, "localhost:5000", "DrugstoreSecretKey")
                
            );
        }
    }
}
