using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    interface IMedicalRecordRepository : IGenericRepository<MedicalRecord, int>
    {
    }
}
