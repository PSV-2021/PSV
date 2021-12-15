using Hospital.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.MedicalRecords.Model;
using Hospital.Medicines.Repository.Interfaces;
using Hospital.Medicines.Repository.Sql;
using Hospital.SharedModel;

namespace Hospital.Medicines.Service
{
    public class DrugService
    {
        private readonly MyDbContext dbContext;
        public IDrugRepository MedicineRepository { get; set; }
        public DrugService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
            MedicineRepository = new DrugSqlRepository(dbContext);
        }

        public DrugService()
        {
            MedicineRepository = new DrugSqlRepository();
        }

        public bool CheckForAmountOfDrug(string nameOfDrug, int amountOfDrug)
        {
            Medicine med = MedicineRepository.GetByName(nameOfDrug);
            if (med == null)
                return false;

            return CheckIsTheDrugAmountSatisfied(amountOfDrug, med);
        }

        private static bool CheckIsTheDrugAmountSatisfied(int amountOfDrug, Medicine med)
        {
            if (med.Supply >= amountOfDrug)
            {
                return true;
            }

            return false;
        }

        public void AddDrugUrgent(string name, int amountOfDrug)
        {
            Medicine med = MedicineRepository.GetByName(name);
            if (med == null)
            {
                MedicineRepository.Save(new Medicine(name, amountOfDrug));
            }
            else
            {
                IncreaseDrugAmount(amountOfDrug, med);
            }
            
        }
        private void IncreaseDrugAmount(int amountOfDrug, Medicine med)
        {
            med.Supply += amountOfDrug;
            MedicineRepository.Update(med);
        }
        private void DecreaseDrugAmount(int amountOfDrug, Medicine med)
        {
            med.Supply -= amountOfDrug;
            MedicineRepository.Update(med);
        }


    }
}
