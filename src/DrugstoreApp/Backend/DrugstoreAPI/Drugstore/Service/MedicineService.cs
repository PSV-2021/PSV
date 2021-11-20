using Drugstore.Repository.Interfaces;
using Drugstore.Models;
using Drugstore.Repository.Sql;
using System.Collections.Generic;
using System.Linq;

namespace DrugstoreAPI.Service
{
    public class MedicineService
    {
        public IMedicineRepository MedicineRepository { get; set; }
        public readonly MyDbContext dbContext;
        public MedicineService(IMedicineRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
        }

        public MedicineService(MyDbContext context)
        {
            this.dbContext = context;
            MedicineRepository = new MedicineSqlRepository(context);
        }

        public List<Medicine> GetAll()
        {
            return MedicineRepository.GetAll();
        }

        public Medicine GetOne(int id)
        {
            return MedicineRepository.GetOne(id);
        }

        public void Add(Medicine medicine)
        {
            MedicineRepository.Add(medicine);
        }

        public bool Delete(int id)
        {
            return MedicineRepository.Delete(id);
        }

        public void PurchaseDrugs(ShoppingCart shoppingCart)
        {
            shoppingCart.ShoppingCartItems.ForEach(item => DecreaseDrugAmount(item.Amount, MedicineRepository.GetByName(item.MedicineName)));
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
            return med.Supply >= amountOfDrug;
        }

        private void DecreaseDrugAmount(int amountOfDrug, Medicine med)
        {
            med.Supply -= amountOfDrug;
            MedicineRepository.Update(med);
        }

        private void IncreaseDrugAmount(int amountOfDrug, Medicine med)
        {
            med.Supply += amountOfDrug;
            MedicineRepository.Update(med);
        }

        public List<Medicine> SearchMedicineByNameAndSubstance(string name, string substance)
        {
            return MedicineRepository.SearchMedicineByNameAndSubstance(name, substance);
        }
    }
}
