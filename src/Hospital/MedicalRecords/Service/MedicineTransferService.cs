using System;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.Medicines.Model;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Service
{
    class MedicineTransferService
    {
        private IMedicineRepository MedicineRepository { get; }
        private IDeclinedMedicineRepository DeclinedMedicineRepository { get; }

        public MedicineTransferService(IMedicineRepository medicineRepository, IDeclinedMedicineRepository declinedMedicineRepository)
        {
            MedicineRepository = medicineRepository;
            DeclinedMedicineRepository = declinedMedicineRepository;
        }

        public DeclinedMedicine DeclineMedicine(Medicine medicineToDecline, String description)
        {
            var declinedMedicine = new DeclinedMedicine(0, medicineToDecline, description);
            MedicineRepository.Delete(medicineToDecline.Id);
            DeclinedMedicineRepository.Save(declinedMedicine);
            return declinedMedicine;
        }
    }
}
