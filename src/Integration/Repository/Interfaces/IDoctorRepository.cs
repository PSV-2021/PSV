using System.Collections.Generic;
using Model;

namespace Integration.Repository.Interfaces
{
    interface IDoctorRepository: IGenericRepository<Doctor, string>
    {
        List<Doctor> GetDoctorsWithSpeciality(Speciality speciality);
    }
}
