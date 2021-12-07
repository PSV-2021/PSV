using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public interface IDoctorService
    {
        public List<Doctor> GetAllDoctors();

        public Doctor GetDoctorBy(int id);
    }
}
