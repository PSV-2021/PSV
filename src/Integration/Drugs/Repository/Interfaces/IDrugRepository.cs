using Integration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository.Interfaces
{
    public interface IDrugRepository
    {
        public List<Drug> GetAll();

        public Drug GetByName(string name);

        public void Update(Drug medicine);
        public void Save(Drug newMedicine);
        public void Remove(Drug medicine);

    }
}
