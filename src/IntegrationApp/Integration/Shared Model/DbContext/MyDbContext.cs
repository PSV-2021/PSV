using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.IntegrationEvents.Model;
using Integration.Model;
using Integration.Tendering.Model;
using Microsoft.EntityFrameworkCore;

namespace Model.DataBaseContext
{
    public class MyDbContext: DbContext
    {
        /*public DbSet<Drug> Medicines
        {
            get; set;
        }*/
        public DbSet<Drugstore> Drugstores { get; set; }
        public DbSet<DrugstoreFeedback> DrugstoreFeedbacks { get; set; }
        public DbSet<DrugstoreOffer> DrugstoreOffers { get; set; }
        public DbSet<DrugConsumed> DrugsConsumed { get; set; }
        public DbSet<DrugTender> DrugTenders { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }
        public DbSet<Event> IntegrationEvents { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Drug>().HasData(
                new Drug(1, "Brufen", 0),
                new Drug(2, "Paracetamol", 0),
                new Drug(3, "Palitreks", 0)
            );*/

            modelBuilder.Entity<Drugstore>(mb =>
            {
                mb.HasData(new Drugstore(1, "Apoteka prva", "http://localhost:5001", "DrugStoreSecretKey",true),

                    new Drugstore(2, "Apoteka druga", "http://localhost:6001", "nestorandom", true),

                    new Drugstore(3, "Apoteka treca", "http://localhost:7001", "gasic", true));

                mb.OwnsOne(e => e.Email).HasData(
                    new { DrugstoreId = 1, EmailValue = "smrdic99@gmail.com" }, //ne osudjujte...
                    new { DrugstoreId = 2, EmailValue = "drugimeil@gmail.com" },
                    new { DrugstoreId = 3, EmailValue = "trecimejl@gmail.com" }
                    );
                mb.OwnsOne(a => a.Address).HasData(
                    new {DrugstoreId = 1, Country = "Srbija", City = "Novi Sad", Street = "Tolstojeva 5"},
                    new { DrugstoreId = 2, Country = "Srbija", City = "Beograd", Street = "Balzakova 31" },
                    new { DrugstoreId = 3, Country = "Srbija", City = "Subotica", Street = "Cara Dusana 56" }
                );
            });

            
            modelBuilder.Entity<DrugstoreOffer>(dof =>
            {
                dof.HasData(new DrugstoreOffer("1", "Content", "title", "Apotekica", false));

                dof.OwnsOne(dr => dr.TimeRange).HasData(
                    new {DrugstoreOfferId = "1", From = new DateTime(2021, 10, 10), To = new DateTime(2021,11, 1)}
                );
            });

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

            modelBuilder.Entity<DrugTender>().HasData(
                new DrugTender("1", DateTime.Now.AddDays(-14), "Brufen - 150, Palitreks - 100, Andol - 40", true),
                new DrugTender("2", DateTime.Now.AddDays(21), "Brufen - 120, Palitreks - 90, Andol - 50", false),
                new DrugTender("3", DateTime.Now.AddDays(-7), "Brufen - 2, Palitreks - 2, Andol - 2", true),
                new DrugTender("4", DateTime.Now.AddDays(-28), "Brufen - 10, Palitreks - 50, Andol - 35", true)
                
            );

            modelBuilder.Entity<TenderOffer>().HasData(
                new TenderOffer("1", "Brufen - 100, Palitreks - 80, Andol - 40",5000, "1", true, 1, false),
                new TenderOffer("2", "Brufen - 120, Palitreks - 50, Andol - 35", 5900, "2", false, 2, true),
                new TenderOffer("3", "Brufen - 2, Palitreks - 2, Andol - 2", 500, "3", true, 1, false),
                new TenderOffer("4", "Brufen - 10, Palitreks - 50, Andol - 35", 2900, "4", false, 1, true),
                new TenderOffer("5", "Brufen - 2, Palitreks - 2, Andol - 2", 500, "3", false, 3, false),
                new TenderOffer("6", "Brufen - 10, Palitreks - 50, Andol - 35", 1900, "4", true, 3, false),
                new TenderOffer("7", "Brufen - 10, Palitreks - 80, Andol - 40", 10000, "1", false, 1, false),
                new TenderOffer("8", "Brufen - 120, Palitreks - 50, Andol - 20", 7900, "2", false, 2, true)
            );
        }
    }
}
