using System;
using Hospital.MedicalRecords.Model;

namespace Hospital.SharedModel
{
    public class DeclinedMedicine
    {
        public int DeclinedMedicineID { get; set; }
        public Medicine Medicine { get; set; }
        public String Description { get; set; }
        public Boolean IsDeleted { get; set; }
        public DeclinedMedicine(int DeclinedMedicineID, Medicine Medicine, String Description)
        {
            this.DeclinedMedicineID = DeclinedMedicineID;
            this.Medicine = Medicine;
            this.Description = Description;
            this.IsDeleted = false;
        }


        public String MedicineName
        {
            get
            {
                if (Medicine != null)
                    return (Medicine.Name);
                else
                    return "";
            }
        }

        public String MedicineManufacturer
        {
            get
            {
                if (Medicine != null)
                    return (Medicine.Manufacturer);
                else
                    return "";
            }
        }
    }
}
