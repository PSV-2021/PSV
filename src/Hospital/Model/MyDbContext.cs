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
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<VacationDays> VacationDays { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<Survey> Survey { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseLazyLoadingProxies(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<UserFeedback>().HasData(
                new UserFeedback { Id = 1, TimeWritten = DateTime.Now, Content = "Good!", Name = "Mika Mikic", canPublish = false },
                new UserFeedback { Id = 2, TimeWritten = DateTime.Now, Content = "I didn't like it.", Name = "Anonymus", canPublish = true },
                new UserFeedback { Id = 3, TimeWritten = DateTime.Now, Content = "Super service!", Name = "Sara Saric", canPublish = true }
            );
            modelBuilder.Entity<Ingridient>().HasData(
               new Ingridient(1, "Panclav"),
               new Ingridient(2, "Penicilin"),
               new Ingridient(3, "Panadol")
              );
            modelBuilder.Entity<Speciality>().HasData(
                new Speciality { Id = 1, Name = "general"}
                );
            modelBuilder.Entity<VacationDays>().HasData(
               new VacationDays { Id = 1, StartDate = new DateTime(2021, 05, 20), EndDate = new DateTime(2021, 05, 25) }
               );
            modelBuilder.Entity<WorkingHours>().HasData(
               new WorkingHours { Id = 1, BeginningDate = new DateTime(2021, 01, 01), Shift = Shift.firstShift, EndDate = new DateTime(2021, 01, 08) }
               );
            modelBuilder.Entity<Doctor>()
                .HasData(
                new Doctor
                {
                    Name = "Milan",
                    Surname = "Popovic",
                    Jmbg = "3009998805137",
                    DateOfBirth = new DateTime(1998, 04, 20),
                    Sex = Sex.male,
                    PhoneNumber = "0641664608",
                    Adress = "Bulevar Oslobodjenja 4",
                    Email = "milan@gmail.com",
                    Username = "miki56",
                    Password = "02145",
                    Type = UserType.doctor,
                    SalaryInRsd = 200000,
                    WorkingSchedule = new List<WorkingHours>(),
                    VacationDays = new List<VacationDays>(),
                    AvailableDaysOff = 20,
                    Id = 1,
                    SpecialityId = 1,
                    NumberOfPatients = 0
                });
           
            modelBuilder.Entity<MedicalRecord>().HasData(
                 new MedicalRecord
                 {
                     Id = 1,
                     HealthInsuranceNumber = "1ab",
                     Allergens = new List<Ingridient>()
                 }
                ) ;
            modelBuilder.Entity<Patient>()
               .HasData(
               new Patient
               {
                   Name = "Marko",
                   Surname = "Markovic",
                   Jmbg = "3009998805138",
                   DateOfBirth = new DateTime(1998, 06, 25),
                   Sex = Sex.male,
                   PhoneNumber = "0641664608",
                   Adress = "Bulevar Oslobodjenja 8",
                   Email = "marko@gmail.com",
                   Username = "miki98",
                   Password = "miki985",
                   Type = UserType.patient,
                   Id = 1,
                   IsBlocked = false,
                   IsActive = true,
                   BloodType = BloodType.B,
                   FathersName = "Petar",
                   DoctorId = 1,
                   MedicalRecordId = 1,
                   Allergen = new List<Allergen>()
               }) ;
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

