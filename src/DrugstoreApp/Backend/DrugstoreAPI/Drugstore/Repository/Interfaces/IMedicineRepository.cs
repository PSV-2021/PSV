using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;

namespace Drugstore.Repository.Interfaces
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetAll();
        public Medicine GetByName(string name);
        public void Update(Medicine med);
    }
}
