using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.Schedule.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Model
{
    public class Patient : User
    {
   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public BloodType BloodType { get; set; }
        public Boolean IsActive { get; set; }
        public String FathersName { get; set; }
        public virtual List<Allergen> Allergen { get; }
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public virtual Doctor ChosenDoctor { get; }
        [ForeignKey("MedicalRecordId")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; }
        
       public String Token { get; set; }

        public Patient() {
           
        }

        public Patient(string name, string surname, string jmbg, BloodType bloodType, string fathersName, Sex sex, string address, string email,
            string username, string phoneNumber, string password, int doctorId, string token, List<Allergen> allergens)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            BloodType = bloodType;
            FathersName = fathersName;
            Sex = sex;
            Adress = address;
            Email = email;
            Username = username;
            PhoneNumber = phoneNumber;
            Password = password;
            DoctorId = doctorId;
            Token = token;
            Allergen = allergens;
            Type = UserType.patient;
        }

        public Patient(int id, string fathersName, string name, string surname, string jmbg, DateTime date, Sex sex, string phoneNumber, string address, string email,
            string username, string password, BloodType bloodType, Boolean isActive, Doctor doc)
        {
            Id = id;
            FathersName = fathersName;
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            DateOfBirth = date;
            Sex = sex;
            PhoneNumber = phoneNumber;
            Adress = address;
            Email = email;
            Username = username;
            Password = password;
            BloodType = bloodType;
            IsActive = isActive;
            ChosenDoctor = doc;
        }

        public Patient(int id, string name, string surname, string username, string password, string jmbg, DateTime date, BloodType btype, string father, 
            Sex sex, string phone, string address, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Jmbg = jmbg;
            DateOfBirth = date;
            BloodType = btype;
            FathersName = father;
            Sex = sex;
            PhoneNumber = phone;
            Adress = address;
            Email = email;
        }

        public Patient(int id, string name, string surname, string jmbg, DateTime date, Sex sex, string phone, string address, string email, string username,
            string password, bool isActive, BloodType btype, string father, int doctorId, int medicalRecordId, List<Allergen> allergens)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Jmbg = jmbg;
            DateOfBirth = date;
            BloodType = btype;
            FathersName = father;
            Sex = sex;
            PhoneNumber = phone;
            Adress = address;
            Email = email;
            IsActive = isActive;
            MedicalRecordId = medicalRecordId;
            DoctorId = doctorId;
            Allergen = allergens;

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

    }
}