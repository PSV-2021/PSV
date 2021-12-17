using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Verification
{
    public class AppointmentVerification
    {
        private AppointmentDTO appointment;

        private bool VerifyFeat(String feat)
        {
            if (feat == null)
                return false;
            return true;
        }

        public bool Verify(AppointmentDTO appointment)
        {
            this.appointment = appointment;
            if (appointment == null)
                return false;
            if (!VerifyFeat(appointment.StartTime))
                return false;
            if (!VerifyFeat(appointment.PatientId))
                return false;
            if (!VerifyFeat(appointment.DoctorId))
                return false;
            return true;
        }
    }
}
