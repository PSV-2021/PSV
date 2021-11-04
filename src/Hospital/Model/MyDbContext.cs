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
                new UserFeedback { Id = 1, TimeWritten = DateTime.Now, Content = "Good!", Name = "Mika Mikic", canPublish = false },
                new UserFeedback { Id = 2, TimeWritten = DateTime.Now, Content = "I didn't like it.", Name = "Anonymus", canPublish = true},
                new UserFeedback { Id = 3, TimeWritten = DateTime.Now, Content = "Super service!", Name = "Sara Saric", canPublish = true }
            );

        }

    }
}

