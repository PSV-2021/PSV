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
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<VacationDays> VacationDays { get; set; }


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
                    SpecialityId = 1
                });
        }

    }
}

