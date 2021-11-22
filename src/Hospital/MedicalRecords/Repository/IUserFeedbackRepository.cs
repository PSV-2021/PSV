using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    interface IUserFeedbackRepository : IGenericRepository<UserFeedback, int>
    {
    }
}