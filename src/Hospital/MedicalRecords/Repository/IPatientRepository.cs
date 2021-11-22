using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    public interface IPatientRepository:IGenericRepository<Patient, string>
    {
    }
}
