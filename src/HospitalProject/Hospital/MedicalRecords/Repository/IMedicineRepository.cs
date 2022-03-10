using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.Medicines.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    public interface IMedicineRepository:IGenericRepository<Medicine, int>
    {
        List<Medicine> GetAwaiting();
        List<Medicine> GetApproved();
    }
}
