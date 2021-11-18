using Drugstore.Repository.Interfaces;
using Drugstore.Models;
using Drugstore.Repository.Sql;

namespace DrugstoreAPI.Service
{
    public class MedicineService
    {
        public IMedicineRepository MedicineRepository { get; set; }
        public MedicineService(IMedicineRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
        }

        public MedicineService()
        {
            MedicineRepository = new MedicineSqlRepository();
        }

        public bool CheckForAmountOfDrug(string nameOfDrug, int amountOfDrug)
        {
            Medicine med = MedicineRepository.GetByName(nameOfDrug);
            if (med == null)
                return false;

            if (CheckIsTheDrugAmountSatisfied(amountOfDrug, med))
            {
                DecreaseDrugAmount(amountOfDrug, med);
                return true;
            }
            return false;
        }

        private bool CheckIsTheDrugAmountSatisfied(int amountOfDrug, Medicine med)
        {
            if (med.Supply >= amountOfDrug) return true;

            return false;
        }

        private void DecreaseDrugAmount(int amountOfDrug, Medicine med)
        {
            med.Supply -= amountOfDrug;
            MedicineRepository.Update(med);
        }
    }
}
