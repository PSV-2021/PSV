using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;

namespace Hospital.MedicalRecords.Service
{
    public class IngredientService
    {
        public IIngredientRepository IngredientRepository { get; set; }

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            IngredientRepository = ingredientRepository;
        }
        public IngredientService()
        {
            IngredientRepository = new IngredientSqlRepository();
        }

        public IngredientService(IngredientSqlRepository ingredientSqlRepository)
        {
            IngredientRepository = ingredientSqlRepository;
        }

        public List<Ingridient> GetAllIngredients()
        {
            return IngredientRepository.GetAll();
        }
    }
}
