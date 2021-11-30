using Hospital.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Medicines.Model;

namespace Hospital.Medicines.Repository.Interfaces
{
    public interface IDrugRepository
    {
        public List<Medicine> GetAll();

        public Medicine GetByName(string name);

        public void Update(Medicine medicine);
        public void Save(Medicine newMedicine);
        public void Remove(Medicine medicine);

    }
}
