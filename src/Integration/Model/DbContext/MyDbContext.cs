using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Microsoft.EntityFrameworkCore;

namespace Model.DataBaseContext
{
    public class MyDbContext: DbContext
    {
        public DbSet<Drugstore> Drugstores { get; set; }
        public DbSet<DrugstoreFeedback> DrugstoreFeedbacks { get; set; }
        public DbSet<DrugstoreOffer> DrugstoreOffers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drugstore>().HasData(

                new Drugstore(1,"Apoteka prva", "http://localhost:5001", "DrugStoreSecretKey", "apoteka1@gmail.com","Novi Sad", "Tolstojeva 3"),
                new Drugstore(2,"Apoteka druga", "http://localhost:5002", "wnjgjowenfweo", "apoteka2@gmail.com", "Novi Sad","Balzakova 3"),
                new Drugstore(3,"Apoteka treca", "http://localhost:5003", "wuhguiwoehfuhw", "apoteka3@gmail.com", "Beograd","Puskinova 3")
            );


            modelBuilder.Entity<DrugstoreFeedback>().HasData(
                new DrugstoreFeedback {Id = "aaa", DrugstoreId = 1, Content = "Nije mi se svidela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now},
                new DrugstoreFeedback { Id = "bbb", DrugstoreId = 2, Content = "Svidjela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now },
                new DrugstoreFeedback { Id = "ccc", DrugstoreId = 3, Content = "Nije mi se svidela usluga", RecievedTime = DateTime.Now, Response = "Nemoj da lazes!", SentTime = DateTime.Now }

            );
            modelBuilder.Entity<DrugstoreOffer>().HasData(
                new DrugstoreOffer("1", "Content", "title", DateTime.Now, DateTime.Now, "Apotekica")
            );
        }
    }
}
