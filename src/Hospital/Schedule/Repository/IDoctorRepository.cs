using System.Collections.Generic;
using Hospital.SharedModel;

namespace Hospital.Schedule.Repository
{
    public interface IDoctorRepository : IGenericRepository<Doctor, string>
    {
        List<Doctor> GetDoctorsWithSpeciality(Speciality speciality);
    }
}
