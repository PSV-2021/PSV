using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Model.DataBaseContext
{
    public class MyDbContext: DbContext
    {
        public DbSet<Drugstore> Drugstores { get; set; }
        public DbSet<DrugstoreFeedback> DrugstoreFeedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drugstore>().HasData(
                new Drugstore { Id = "aaa" , Name = "Apoteka 1", Url = @"http://apoteka1.rs"},
                new Drugstore { Id = "bbb", Name = "Apoteka 2", Url = @"http://apoteka2.rs" },
                new Drugstore { Id = "ccc", Name = "Apoteka 3", Url = @"http://apoteka3.rs" }

            );


            modelBuilder.Entity<DrugstoreFeedback>().HasData(
                new DrugstoreFeedback { Id = 1, DrugstoreToken = "tokentokentoken123", Content = "Nije mi se svidela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now},
                new DrugstoreFeedback { Id = 2, DrugstoreToken = "tokentokentoken456", Content = "Svidjela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now },
                new DrugstoreFeedback { Id = 3, DrugstoreToken = "tokentokentoken789", Content = "Nije mi se svidela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now }

            );
        }
    }
}
