using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public String ApointmentDescription { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public ReportDTO() { }

    }
}
