using Hospital.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class MedicalRecordDTO : PatientDto
    {
        public String DoctorName { get; set; }
        public String Gender { get; set; }
        public String BType { get; set; }
        public MedicalRecordDTO(Patient resultPatient)
        {
            Name = resultPatient.Name;
            Surname = resultPatient.Surname;
            Username = resultPatient.Username;
            Password = resultPatient.Password;
            Jmbg = resultPatient.Jmbg;
            Date = resultPatient.DateOfBirth.ToString();
            BType = resultPatient.BloodType.ToString();
            FathersName = resultPatient.FathersName;
            Gender = resultPatient.Sex.ToString();
            PhoneNumber = resultPatient.PhoneNumber;
            Address = resultPatient.Adress;
            Email = resultPatient.Email;
        }

        public MedicalRecordDTO()
        {
        }
    }
}
