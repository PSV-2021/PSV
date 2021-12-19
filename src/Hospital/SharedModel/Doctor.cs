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
        public int Id { get; private set; }
        [ForeignKey("SpecialityId")]
        public int SpecialityId { get; private set; }
        public virtual Speciality Speciality { get; }
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
            Validate();

    }

        public Doctor() {
        }

        public Doctor(string name, string surname, string jmbg, DateTime date, string phone, string address, string email, string username, string password, 
            UserType type, int salary, int id, int specialtyId, int numberOfPatients, Sex sex)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            DateOfBirth = date;
            PhoneNumber = phone;
            Adress = address;
            Email = email;
            Username = username;
            Password = password;
            Type = type;
            SalaryInRsd = salary;
            Id = id;
            SpecialityId = specialtyId;
            NumberOfPatients = numberOfPatients;
            Sex = sex;
            Validate();
        }

        public string NameAndSurname
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }
        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));
            if (SpecialityId < 0)
                throw new ArgumentException(String.Format("SpecialityId must be positive number"));
            if (NumberOfPatients < 0)
                throw new ArgumentException(String.Format("NumberOfPatients must be positive number"));
        }
    }
}
