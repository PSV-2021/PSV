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
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public int AppointmentId { get; set; }
        public Survey() { }

        public Survey(int patientId, DateTime date, int appointmentId) 
        {
            PatientId = patientId;
            Date = date;
            AppointmentId = appointmentId;
        }
    }
}
