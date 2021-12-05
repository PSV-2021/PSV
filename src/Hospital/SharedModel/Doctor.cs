using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.Schedule.Model;

namespace Hospital.SharedModel
{
    public class Doctor : Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual List<WorkingHours> WorkingSchedule { get; set; }

        [ForeignKey("WorkingHoursId")]
        public int WorkingHoursId { get; set; }
        public virtual WorkingHours WorkingHours { get; set; }
        public int AvailableDaysOff { get; set; }
        public virtual List<VacationDays> VacationDays { get; set; }
        [ForeignKey("SpecialityId")]
        public int SpecialityId { get; set; }
       
        public virtual Speciality Speciality { get; set; }
        public int NumberOfPatients { get; set; }

        public Doctor(string name, string surname, string jmbg, DateTime date, Sex sex, string phoneNumber,
            string adress, string email, int salary, string username, string password)
        {

            this.Name = name;
            this.Surname = surname;
            this.Jmbg = jmbg;
            this.DateOfBirth = date;
            this.Sex = sex;
            this.PhoneNumber = phoneNumber;
            this.Adress = adress;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.Type = UserType.doctor;
            this.SalaryInRsd = salary;
            this.Speciality = new Speciality();
            //WorkingSchedule = new List<WorkingHours>();
            VacationDays = new List<VacationDays>();
            AvailableDaysOff = 20;

    }

        public Doctor() {
        }

        public string NameAndSurname
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public string SpecialityName
        {
            get
            {
                return Speciality.Name;
            }
        }
        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }
    }
}
