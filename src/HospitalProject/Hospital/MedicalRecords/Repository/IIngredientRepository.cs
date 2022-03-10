using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    public interface IIngredientRepository: IGenericRepository<Ingridient, int>
    { 
    }
}