using Integration.Model;
using Integration.Repository.Interfaces;
using Integration.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
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
            Drug med = MedicineRepository.GetByName(nameOfDrug);
            if (med == null)
                return false;

            return CheckIsTheDrugAmountSatisfied(amountOfDrug, med);
        }

        private static bool CheckIsTheDrugAmountSatisfied(int amountOfDrug, Drug med)
        {
            if (med.Supply >= amountOfDrug)
            {
                return true;
            }

            return false;
        }

        public void AddDrugUrgent(string nameOfDrug, int amountOfDrug)
        {
            Drug med = MedicineRepository.GetByName(nameOfDrug);
            if (med == null)
            {
                MedicineRepository.Save(new Drug(nameOfDrug, amountOfDrug));
            }
            else
            {
                IncreaseDrugAmount(amountOfDrug, med);
            }
            
        }
        private void IncreaseDrugAmount(int amountOfDrug, Drug med)
        {
            med.Supply += amountOfDrug;
            MedicineRepository.Update(med);
        }
        private void DecreaseDrugAmount(int amountOfDrug, Drug med)
        {
            med.Supply -= amountOfDrug;
            MedicineRepository.Update(med);
        }


    }
}
