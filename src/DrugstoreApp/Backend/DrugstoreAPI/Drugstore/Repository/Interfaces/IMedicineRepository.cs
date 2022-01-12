using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;

namespace Drugstore.Repository.Interfaces
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetAll();
        public Medicine GetOne(int id);
        public void Add(Medicine medicine);
        public bool Delete(int id);
        public Medicine GetByName(string name);
        public Medicine GetByName1(string name);
        public void Update(Medicine med);
    }
}
