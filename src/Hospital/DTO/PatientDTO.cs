using Hospital.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DTO
{
    public class PatientDTO
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
        public List<Ingridient> Allergens { get; set; }
        public PatientDTO() { }
    }
}
