using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Model;
using Microsoft.EntityFrameworkCore;
using Hospital.DTO;

namespace Hospital.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<Survey> Survey { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFeedback>().HasData(
                new UserFeedback { Id = 1, TimeWritten = DateTime.Now, Content = "Good!", Name = "Mika Mikic", canPublish = false },
                new UserFeedback { Id = 2, TimeWritten = DateTime.Now, Content = "I didn't like it.", Name = "Anonymus", canPublish = true},
                new UserFeedback { Id = 3, TimeWritten = DateTime.Now, Content = "Super service!", Name = "Sara Saric", canPublish = true }
            );

            modelBuilder.Entity<SurveyQuestion>().HasData(
                new SurveyQuestion { Id = 1, Text = "How satisfied are you with the work of your doctor?", Rating = 0, QuestionType = 0 },
                new SurveyQuestion { Id = 2, Text = "How satisfied were you with the time that your doctor spent with you?", Rating = 0, QuestionType = 0 },
                new SurveyQuestion { Id = 3, Text = "During this hospital stay, did doctor treat you with courtesy and respect?", Rating = 0, QuestionType = 0 },
                new SurveyQuestion { Id = 4, Text = "During this hospital stay, did doctor listen carefully to you?", Rating = 0, QuestionType = 0 },
                new SurveyQuestion { Id = 5, Text = "During this hospital stay, did doctor explain things in a way you could understand?", Rating = 0, QuestionType = 0 },
                new SurveyQuestion { Id = 6, Text = "During this hospital stay, did nurses treat you with courtesy and respect?", Rating = 0, QuestionType = 1 },
                new SurveyQuestion { Id = 7, Text = "During this hospital stay, did nurses listen carefully to you?", Rating = 0, QuestionType = 1 },
                new SurveyQuestion { Id = 8, Text = "During this hospital stay, did nurses explain things in a way you could understand?", Rating = 0, QuestionType = 1 },
                new SurveyQuestion { Id = 9, Text = "How easy was it to schedule an appointment with our hospital?", Rating = 0, QuestionType = 2 },
                new SurveyQuestion { Id = 10, Text = "How satisfied are you with the cleanliness and appearance of our hospital?", Rating = 0, QuestionType = 2 },
                new SurveyQuestion { Id = 11, Text = "How would you rate the professionalism of our staff?", Rating = 0, QuestionType = 2 },
                new SurveyQuestion { Id = 12, Text = "How satisfied were you with the co-ordination between different departments?", Rating = 0, QuestionType = 2 },
                new SurveyQuestion { Id = 13, Text = "Do you feel that our work hours are well suited to treat you?", Rating = 0, QuestionType = 2 },
                new SurveyQuestion { Id = 14, Text = "How likely are you to recommend our hospital to a friend or family member?", Rating = 0, QuestionType = 2 }
            );


        }

    }
}

