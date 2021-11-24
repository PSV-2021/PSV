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
        public DbSet<Medicine> Medicines
        {
            get; set;
        }
        public DbSet<Drugstore> Drugstores { get; set; }
        public DbSet<DrugstoreFeedback> DrugstoreFeedbacks { get; set; }
        public DbSet<DrugstoreOffer> DrugstoreOffers { get; set; }
        public DbSet<DrugConsumed> DrugsConsumed { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine(1, "Brufen", 0),
                new Medicine(2, "Paracetamol", 0),
                new Medicine(3, "Palitreks", 0)
            );
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
                new DrugstoreOffer("1", "Content", "title", DateTime.Now, DateTime.Now, "Apotekica",false)
            );

            modelBuilder.Entity<DrugConsumed>().HasData(
                new DrugConsumed(1, "Brufen", 98, new DateTime(2021, 11, 14)),
                new DrugConsumed(2, "Palitrex", 65, new DateTime(2021, 11, 14)),
                new DrugConsumed(3, "Amoksicilin", 45, new DateTime(2021, 11, 14)),
                new DrugConsumed(4, "Sinacilin", 43, new DateTime(2021, 11, 14)),
                new DrugConsumed(5, "Andol", 67, new DateTime(2021, 11, 14)),
                new DrugConsumed(6, "Panadol", 65, new DateTime(2021, 11, 14)),
                new DrugConsumed(7, "Panklav", 36, new DateTime(2021, 11, 14)),

                new DrugConsumed(8, "Brufen", 76, new DateTime(2021, 11, 15)),
                new DrugConsumed(9, "Palitrex", 56, new DateTime(2021, 11, 15)),
                new DrugConsumed(10, "Amoksicilin", 54, new DateTime(2021, 11, 15)),
                new DrugConsumed(11, "Sinacilin", 34, new DateTime(2021, 11, 15)),
                new DrugConsumed(12, "Andol", 87, new DateTime(2021, 11, 15)),
                new DrugConsumed(13, "Panadol", 67, new DateTime(2021, 11, 15)),
                new DrugConsumed(14, "Panklav", 33, new DateTime(2021, 11, 15)),

                new DrugConsumed(15, "Brufen", 78, new DateTime(2021, 11, 16)),
                new DrugConsumed(16, "Palitrex", 66, new DateTime(2021, 11, 16)),
                new DrugConsumed(17, "Amoksicilin", 48, new DateTime(2021, 11, 16)),
                new DrugConsumed(18, "Sinacilin", 44, new DateTime(2021, 11, 16)),
                new DrugConsumed(19, "Andol", 56, new DateTime(2021, 11, 16)),
                new DrugConsumed(20, "Panadol", 75, new DateTime(2021, 11, 16)),
                new DrugConsumed(21, "Panklav", 39, new DateTime(2021, 11, 16)),

                new DrugConsumed(22, "Brufen", 105, new DateTime(2021, 11, 17)),
                new DrugConsumed(23, "Palitrex", 66, new DateTime(2021, 11, 17)),
                new DrugConsumed(24,"Amoksicilin", 42, new DateTime(2021, 11, 17)),
                new DrugConsumed(25, "Sinacilin", 54, new DateTime(2021, 11, 17)),
                new DrugConsumed(26, "Andol", 77, new DateTime(2021, 11, 17)),
                new DrugConsumed(27, "Panadol", 64, new DateTime(2021, 11, 17)),
                new DrugConsumed(28, "Panklav", 38, new DateTime(2021, 11, 17)),

                new DrugConsumed(29, "Brufen", 78, new DateTime(2021, 11, 18)),
                new DrugConsumed(30, "Palitrex", 66, new DateTime(2021, 11, 18)),
                new DrugConsumed(31, "Amoksicilin", 87, new DateTime(2021, 11, 18)),
                new DrugConsumed(32, "Sinacilin", 56, new DateTime(2021, 11, 18)),
                new DrugConsumed(33, "Andol", 45, new DateTime(2021, 11, 18)),
                new DrugConsumed(34, "Panadol", 56, new DateTime(2021, 11, 18)),
                new DrugConsumed(35, "Panklav", 76, new DateTime(2021, 11, 18)),

                new DrugConsumed(36, "Brufen", 93, new DateTime(2021, 11, 19)),
                new DrugConsumed(37, "Palitrex", 62, new DateTime(2021, 11, 19)),
                new DrugConsumed(38, "Amoksicilin", 49, new DateTime(2021, 11, 19)),
                new DrugConsumed(39, "Sinacilin", 46, new DateTime(2021, 11, 19)),
                new DrugConsumed(40, "Andol", 72, new DateTime(2021, 11, 19)),
                new DrugConsumed(41, "Panadol", 60, new DateTime(2021, 11, 19)),
                new DrugConsumed(42, "Panklav", 34, new DateTime(2021, 11, 19)),

                new DrugConsumed(43, "Brufen", 97, new DateTime(2021, 11, 20)),
                new DrugConsumed(44, "Palitrex", 62, new DateTime(2021, 11, 20)),
                new DrugConsumed(45, "Amoksicilin", 39, new DateTime(2021, 11, 20)),
                new DrugConsumed(46, "Sinacilin", 46, new DateTime(2021, 11, 20)),
                new DrugConsumed(47, "Andol", 77, new DateTime(2021, 11, 20)),
                new DrugConsumed(48, "Panadol", 60, new DateTime(2021, 11, 20)),
                new DrugConsumed(49, "Panklav", 38, new DateTime(2021, 11, 20))
            );
        }
    }
}
