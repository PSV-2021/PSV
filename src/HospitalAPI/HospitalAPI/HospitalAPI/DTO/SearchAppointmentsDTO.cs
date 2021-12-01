using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class SearchAppointmentsDTO
    {
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int Priority { get; set; }
        public int SpecializationId { get; set; }
        public SearchAppointmentsDTO() { }
    }
}
