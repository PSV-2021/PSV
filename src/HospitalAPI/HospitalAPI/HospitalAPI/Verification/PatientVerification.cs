using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalAPI.Verification
{
    public class PatientVerification
    {
        private PatientDto patient;

        public PatientVerification() { }

        private bool VerifyName()
        {
            Regex regex = new Regex("[A-ZČĆŠĐŽčćđžš][a-zčćđžš]*");
            if (patient.Name == null)
                return false;
            if (!regex.IsMatch(patient.Name))
                return false;
            return true;
        }
        private bool VerifySurname()
        {
            Regex regex = new Regex("[A-Z][a-z]*");
            if (patient.Surname == null)
                return false;
            if (!regex.IsMatch(patient.Surname))
                return false;
            return true;
        }
        private bool VerifyFathersName()
        {
            Regex regex = new Regex("[A-ZČĆŠĐŽčćđžš][a-zčćđžš]*");
            if (patient.FathersName == null)
                return false;
            if (!regex.IsMatch(patient.FathersName))
                return false;
            return true;
        }
        private bool VerifyPhone()
        {
            Regex regex = new Regex("[0-9]*");
            if (patient.PhoneNumber == null)
                return false;
            if (!regex.IsMatch(patient.PhoneNumber))
                return false;
            return true;
        }
        private bool VerifyAddress()
        {
            Regex regex = new Regex("[A-ZČĆŠĐŽ][a-z A-z0-9ČĆŠĐŽčćđžš]*");
            if (patient.Address == null)
                return false;
            if (!regex.IsMatch(patient.Address))
                return false;
            return true;
        }
        private bool VerifyEmail()
        {
            Regex regex = new Regex("^(.+)@(.+)$");
            if (patient.Email == null)
                return false;
            if (!regex.IsMatch(patient.Email))
                return false;
            return true;
        }
        private bool VerifyImage()
        {
            if (patient.Image == null)
                return false;
            return true;
        }

        public bool Verify(PatientDto patient)
        {
            this.patient = patient;
            if (patient == null)
                return false;
            if (!VerifyName())
                return false;
            if (!VerifySurname())
                return false;
            if (!VerifyFathersName())
                return false;
            if (!VerifyPhone())
                return false;
            if (!VerifyAddress())
                return false;
            if (!VerifyEmail())
                return false;
            return true;
        }
        public bool VerifyImage(PatientDto patient)
        {
            this.patient = patient;
            if (!VerifyImage())
                return false;
            return true;
        }
    }
}
