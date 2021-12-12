using System;
using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.Medicines.Model;

namespace Hospital.MedicalRecords.Service
{
    public class MedicineService
    {

        private IMedicineRepository MedicineRepository { get; }

        public MedicineService(IMedicineRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
        }
        public List<Medicine> GetApproved()
        {
            return MedicineRepository.GetApproved();
        }

        public List<Medicine> GetAwaiting()
        {
            return MedicineRepository.GetAwaiting();
        }

        public List<Medicine> GetPossibleReplacements(Medicine medicine)
        {
            List<Medicine> medicineForReplacement = GetApproved();
            foreach (var replacement in medicineForReplacement)
            {
                if (replacement.Id == medicine.Id)
                {
                    medicineForReplacement.Remove(replacement);
                    break;
                }
            }

            return medicineForReplacement;
        }

        public Boolean UpdateMedicine(Medicine updatedMedicine)
        {
            return MedicineRepository.Update(updatedMedicine);
        }

        public Boolean DeleteMedicine(int medicineID)
        {
            return MedicineRepository.Delete(medicineID);
        }
        /*
        public void ApproveMedicine(Medicine medicineToApprove)
        {
            medicineToApprove.Status = MedicineStatus.approved;
            UpdateMedicine(medicineToApprove);
        }
        */

        public Medicine getMedicineById(int medicineId)
        {
            return MedicineRepository.GetOne(medicineId);
        }
        public List<Medicine> GetAllMedicine()
        {
            return MedicineRepository.GetAll();
        }

        public void SaveMedicine(Medicine newMedicine)
        {
            MedicineRepository.Save(newMedicine);
        }

    }
}
