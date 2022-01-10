using System;
using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.Medicines.Model;
using Hospital.Schedule.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.SharedModel
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<VacationDays> VacationDays { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestion { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<UserFeedback>().HasData(
                new UserFeedback( 1, DateTime.Now, "Good!", "Mika Mikic", false ),
                new UserFeedback(2, DateTime.Now, "I didn't like it.", "Anonymus",  true ),
                new UserFeedback(3, DateTime.Now, "Super service!", "Sara Saric",  true )
            );
            modelBuilder.Entity<Ingridient>().HasData(
               new Ingridient(1, "Panclav"),
               new Ingridient(2, "Penicilin"),
               new Ingridient(3, "Panadol")
              );
            modelBuilder.Entity<Speciality>().HasData(
                new Speciality(1, "general"),
                new Speciality(2, "cardiology")
                );
            modelBuilder.Entity<VacationDays>().HasData(
               new VacationDays { Id = 1, StartDate = new DateTime(2021, 05, 20), EndDate = new DateTime(2021, 05, 25)}
               );
            modelBuilder.Entity<WorkingHours>().HasData(
               new WorkingHours { Id = 1, BeginningDate = new DateTime(2021, 01, 01), Shift = Shift.firstShift, EndDate = new DateTime(2021, 01, 08) }
               );
            modelBuilder.Entity<Doctor>()
                .HasData(
                new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 0, Sex.male),
                new Doctor("Milica", "Milic", "3052123545852", new DateTime(1987, 04, 21), "0691457608", "Ravanicka 8", "milica@gmail.com",
                "mica56", "mica1234", UserType.doctor, 250000, 2, 2, 0, Sex.female)
                );
            modelBuilder.Entity<Patient>(mb =>
            {

                mb.HasData(
               new Patient(1, "Marko", "Markovic", "3009998805138", new DateTime(1998, 06, 25), Sex.male, "0641664608",
                "Bulevar Oslobodjenja 8", "marko@gmail.com", "miki98", "miki985", true, BloodType.B, "Petar", 1, new List<Allergen>(),"0"),
               new Patient(2, "Milica", "Mikic", "3009998805137", new DateTime(1997, 10, 12), Sex.female, "065245987", "Kisacka 5", "milica@gmail.com",
               "mici97", "mici789", true, BloodType.A, "Nenad", 1, new List<Allergen>(),"0")
               );

                mb.OwnsOne(p => p.MedicalRecord).HasData(
                  new { PatientId = 1, HealthInsuranceNumber = "1ab", CompanyName = "WellCare" },
                  new { PatientId = 2, HealthInsuranceNumber = "2ab", CompanyName = "WellCare" });
            });


            modelBuilder.Entity<SurveyQuestion>().HasData(
                new SurveyQuestion( 1, "How satisfied are you with the work of your doctor?", 0, 0),
                new SurveyQuestion(2, "How satisfied were you with the time that your doctor spent with you?", 0, 0),
                new SurveyQuestion(3, "During this hospital stay, did doctor treat you with courtesy and respect?", 0, 0),
                new SurveyQuestion(4, "During this hospital stay, did doctor listen carefully to you?", 0, 0),
                new SurveyQuestion(5, "During this hospital stay, did doctor explain things in a way you could understand?", 0, 0),
                new SurveyQuestion(6, "During this hospital stay, did nurses treat you with courtesy and respect?", 0, 1),
                new SurveyQuestion(7, "During this hospital stay, did nurses listen carefully to you?", 0, 1),
                new SurveyQuestion(8, "During this hospital stay, did nurses explain things in a way you could understand?", 0, 1),
                new SurveyQuestion(9, "How easy was it to schedule an appointment with our hospital?", 0, 2),
                new SurveyQuestion(10, "How satisfied are you with the cleanliness and appearance of our hospital?", 0, 2),
                new SurveyQuestion(11, "How would you rate the professionalism of our staff?", 0, 2),
                new SurveyQuestion(12, "How satisfied were you with the co-ordination between different departments?", 0, 2),
                new SurveyQuestion(13, "Do you feel that our work hours are well suited to treat you?", 0, 2),
                new SurveyQuestion(14, "How likely are you to recommend our hospital to a friend or family member?", 0, 2)
            );
            modelBuilder.Entity<Medicine>().HasData(new Medicine(1, "Brufen", 200, 100, "Pfizer", "Umres", "Pa umres", "Kad god hoces", 100, "Mozes sve lagano", ""));

            //modelBuilder.Entity<Prescription>().HasData(new Prescription(1,"Zoran Zoranic", "Random opis nekog leka", "Palitrex", DateTime.Now));
            modelBuilder.Entity<Appointment>().HasData(
             new Appointment(1, new DateTime(2021, 12, 07, 16, 30, 00), 30, "All good", false, 1, 1, false, true),
             new Appointment(2, new DateTime(2021, 12, 31, 16, 30, 00), 30, "", false, 1, 2, false, true),
             new Appointment(3, new DateTime(2021, 12, 07, 14, 30, 00), 30, "All good", false, 1, 2, false, true),
             new Appointment(4, new DateTime(2021, 11, 15, 14, 00, 00), 30, "All good", false, 1, 2, true, true)
            );
            modelBuilder.Entity<Prescription>().HasData(new Prescription(1,"Zoran Zoranic", "Random opis nekog leka", "Palitrex", DateTime.Now));
        }

    }


}
