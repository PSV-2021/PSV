using Hospital.Medicines.Model;

namespace Hospital.MedicalRecords.Model
{
    public class MedicineCount
    {
        public Medicine Medicine { get; set; }
        public int Count { get; set; }

        public MedicineCount(Medicine medicine, int count) {
            Medicine = medicine;
            Count = count;
        }
    }
}
