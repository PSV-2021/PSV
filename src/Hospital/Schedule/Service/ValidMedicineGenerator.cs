using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;

namespace Hospital.Schedule.Service
{
    public class ValidMedicineGenerator
    {
        private IMedicineRepository MedicineRepository { get; }
        public ValidMedicineGenerator(IMedicineRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
        }

        public List<Medicine> GenerateValidMedicineForPatient(MedicalRecord medicalRecord)
        {
            var allApprovedMedicine = MedicineRepository.GetApproved();
            List<Medicine> validMedicine = new List<Medicine>();
            foreach (var medicine in allApprovedMedicine)
            {
                if (!AllergenMatchFound(medicine, medicalRecord))
                    validMedicine.Add(medicine);
            }

            return validMedicine;
        }

        private bool AllergenMatchFound(Medicine medicine, MedicalRecord medicalRecord)
        {
            var allergenMatchFound = false;
            foreach (var ingredient in medicine.ingridient)
            {
                foreach (var allergen in medicalRecord.Allergens)
                {
                    if (ingredient.Name.Equals(allergen.Name))
                    {
                        allergenMatchFound = true;
                    }
                }
            }

            return allergenMatchFound;
        }
    }
}
