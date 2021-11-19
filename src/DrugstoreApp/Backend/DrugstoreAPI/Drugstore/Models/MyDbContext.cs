﻿using Drugstore.Models;
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
        public DbSet<DrugstoreOffer> DrugstoreOffers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine(1, "Brufen", 150, 150),
                new Medicine(2, "Paracetamol", 150, 10),
                new Medicine(3, "Palitreks", 150, 30)
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback("Health", "aaa", "Lenka vrati zeton", ""),
                new Feedback("Ime bolnice 223", "bbb", "normalno", ""),
                new Feedback("Ime bolnice 224", "ccc", "bla bla", "")

            );

            modelBuilder.Entity<Hospital>().HasData(
                new Hospital("Health", 1, "http://localhost:5000", "DrugStoreSecretKey")

            );
            modelBuilder.Entity<DrugstoreOffer>().HasData(
                new DrugstoreOffer("1", "Content", "title", DateTime.Now, DateTime.Now,"Apotekica")

            ); 
        }
    }
}
