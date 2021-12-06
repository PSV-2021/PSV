using System;
using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace HospitalAPI.DTO
{
    public class PatientDto
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Jmbg { get; set; }
        public String Date { get; set; }
        public BloodType BloodType { get; set; }
        public String FathersName { get; set; }
        public Sex Sex { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int DoctorId { get; set; }
        public string Token { get; set; }
        public List<String> Allergens { get; set; }
        public PatientDto() { }
    }
}
