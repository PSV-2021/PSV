using System.Collections.Generic;
using Model;

namespace Integration_API.Repository.Interfaces
{
    interface IDoctorRepository: IGenericRepository<Doctor, string>
    {
        List<Doctor> GetDoctorsWithSpeciality(Speciality speciality);
    }
}
