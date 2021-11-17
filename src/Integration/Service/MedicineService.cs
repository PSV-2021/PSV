using Integration.Model;
using Integration.Repository.Interfaces;
using Integration.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
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

        public void AddDrugUrgent(string nameOfDrug, int amountOfDrug)
        {
            Medicine med = MedicineRepository.GetByName(nameOfDrug);
            if (med == null)
            {
                MedicineRepository.Save(new Medicine(nameOfDrug, amountOfDrug));
            }
            else
            {
                med.Supply += amountOfDrug;
                MedicineRepository.Update(med);
            }
            
        }


    }
}
