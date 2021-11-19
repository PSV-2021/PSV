using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Patient : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public Boolean IsBlocked { get; set; }
        public BloodType BloodType { get; set; }
        public Boolean IsActive { get; set; }
        public String FathersName { get; set; }
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public virtual Doctor ChosenDoctor { get; set; }
        public String EmergencyContact { get; set; }
        [ForeignKey("MedicalRecordId")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public Patient() { }
        public Patient(string name, string surname, string jmbg , DateTime date, Sex sex, string phoneNumber, string adress, string email, string emContact, MedicalRecord med, string username, string password, Boolean block = false)
        {
            this.Name = name;
            this.Surname = surname;
            this.Jmbg = jmbg;
            this.DateOfBirth = date;
            this.Sex = sex;
            this.PhoneNumber = phoneNumber;
            this.Adress = adress;
            this.Email = email;
            this.EmergencyContact = emContact;
            this.MedicalRecord = med;
            this.Username = username;
            this.Password = password;
            this.appointment = null;
            this.Type = UserType.patient;
            this.IsBlocked = block;
        }

        public Patient(string name, string fathersName, string surname, string jmbg, DateTime date, Sex sex, string phoneNumber, string adress, string email, MedicalRecord med, string username, string password, BloodType bt, Boolean isActive, Doctor cd, Boolean block = false)
        {
            this.Name = name;
            this.FathersName = fathersName;
            this.Surname = surname;
            this.Jmbg = jmbg;
            this.DateOfBirth = date;
            this.Sex = sex;
            this.PhoneNumber = phoneNumber;
            this.Adress = adress;
            this.Email = email;
            this.MedicalRecord = med;
            this.Username = username;
            this.Password = password;
            this.appointment = null;
            this.Type = UserType.patient;
            this.IsBlocked = block;
            this.BloodType = bt;
            this.IsActive = isActive;
            this.ChosenDoctor = cd;
        }

        public string NameAndSurname
        {
            get
            {
                return Name + " " + Surname;
            }
        }

        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        public List<Ingridient> Allergens
        {
            set
            {
                MedicalRecord.Allergen = value;
            }
        }
        
        public List<Appointment> appointment;

        [NotMapped]
        public List<Appointment> Appointment
        {
            get
            {
                if (appointment == null)
                    appointment = new List<Appointment>();
                return appointment;
            }
            set
            {
                RemoveAllAppointment();
                if (value != null)
                {
                    foreach (Appointment oAppointment in value)
                        AddAppointment(oAppointment);
                }
            }
        }


        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new System.Collections.Generic.List<Appointment>();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.Patient = this;
            }
        }


        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.Patient = null;
                }
        }


        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.Patient = null;
                tmpAppointment.Clear();
            }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }

    }
}