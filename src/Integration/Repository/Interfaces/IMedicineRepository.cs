using Integration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository.Interfaces
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetAll();

        public Medicine GetByName(string name);

        public void Update(Medicine medicine);
        public void Save(Medicine newMedicine);

    }
}
