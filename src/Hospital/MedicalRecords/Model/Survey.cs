using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.MedicalRecords.Model
{
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int PatientId { get; private set; }
        public DateTime Date { get; private set; }
        public int AppointmentId { get; set; }
        public Survey() { }

        public Survey(int patientId, DateTime date, int appointmentId) 
        {
            PatientId = patientId;
            Date = date;
            AppointmentId = appointmentId;
        }

        public bool IdEqual(List<Survey> surveys,int id)
        {
            foreach (Survey s in surveys)
            {
                if (s.AppointmentId == id)
                    return true;
            }
            return false;
        }

        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));
            if (PatientId < 0)
                throw new ArgumentException(String.Format("PatientId must be positive number"));
            if (AppointmentId < 0)
                throw new ArgumentException(String.Format("AppointmentId must be positive number"));
        }
    }
}
