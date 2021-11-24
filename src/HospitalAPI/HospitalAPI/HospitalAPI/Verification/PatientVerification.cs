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
        private Regex regexName = new Regex("[A-ZČĆŠĐŽčćđžš][a-zčćđžš]*");
        private Regex regexPhone = new Regex("[0-9]*");
        private Regex regexAddress = new Regex("[A-ZČĆŠĐŽ][a-z A-z0-9ČĆŠĐŽčćđžš]*");
        private Regex regexEmail = new Regex("^(.+)@(.+)$");

        public PatientVerification() { }

        private bool VerifyField(Regex r, String s)
        {
            if (s == null)
                return false;
            if (!r.IsMatch(s))
                return false;
            return true;
        }

        public bool Verify(PatientDto patient)
        {
            this.patient = patient;
            if (patient == null)
                return false;
            if (!VerifyField(regexName, patient.Name))
                return false;
            if (!VerifyField(regexName, patient.Surname))
                return false;
            if (!VerifyField(regexName, patient.FathersName))
                return false;
            if (!VerifyField(regexPhone, patient.PhoneNumber))
                return false;
            if (!VerifyField(regexAddress, patient.Address))
                return false;
            if (!VerifyField(regexEmail, patient.Email))
                return false;
            return true;
        }
    }
}
