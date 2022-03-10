using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class AppointmentDTO
    {
        public String StartTime { get; set; }
        public String PatientId { get; set; }
        public String DoctorId { get; set; }
        public AppointmentDTO()
        {

        }
    }
}
