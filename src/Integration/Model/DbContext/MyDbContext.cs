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
                new Drugstore(1,"Apoteka prva", "www.apoteka.rs", "aaabbbccc"),
                new Drugstore(2,"Apoteka druga", "www.apotekica.rs", "111222333"),
                new Drugstore(3,"Apoteka treca", "www.apotekcina.rs", "555333")

            );


            modelBuilder.Entity<DrugstoreFeedback>().HasData(
                new DrugstoreFeedback {Id = 1, DrugstoreId = 1, Content = "Nije mi se svidela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now},
                new DrugstoreFeedback { Id = 2, DrugstoreId = 2, Content = "Svidjela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now },
                new DrugstoreFeedback { Id = 3, DrugstoreId = 3, Content = "Nije mi se svidela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now }

            );
        }
    }
}
