using Hospital.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.MedicalRecords.Model;
using Hospital.Medicines.Repository.Interfaces;
using Hospital.Medicines.Repository.Sql;

namespace Hospital.Medicines.Service
{
    public class DrugService
    {
        public IDrugRepository MedicineRepository { get; set; }
        public DrugService(IDrugRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
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
                //med = new Medicine(name, amountOfDrug);
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
