using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserFeedback> UserFeedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFeedback>().HasData(
                new UserFeedback { Id = 1, Date = "20/05/2021", Content = "Good!", Name = "Mika Mikic", canPublish = true },
                new UserFeedback { Id = 2, Date = "21/06/2020", Content = "I didn't like it.", Name = "Anonymus", canPublish = true},
                new UserFeedback { Id = 3, Date = "22/07/2021", Content = "Super service!", Name = "Sara Saric", canPublish = true }
            );

        }

    }
}

