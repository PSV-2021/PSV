using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DTO
{
    public class SearchAppointmentsDTO
    {
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public int DoctorId { get; set; }
        public int Priority { get; set; }
        public int SpecializationId { get; set; }
        public SearchAppointmentsDTO() { }
    }
}
