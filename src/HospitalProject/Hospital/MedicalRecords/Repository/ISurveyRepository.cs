using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    public interface ISurveyRepository : IGenericRepository<Survey, int>
    {
        public bool CheckIfExistsById(int id);
        public void CreateSurvey(Survey survey);
    }
}
