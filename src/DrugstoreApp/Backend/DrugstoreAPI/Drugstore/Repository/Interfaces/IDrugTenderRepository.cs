using Drugstore.Models;
using System.Collections.Generic;

namespace Drugstore.Repository.Interfaces
{
    public interface IDrugTenderRepository 
    {
        public List<DrugTender>GetAll();
        public DrugTender GetOne(int id);
        public void Add(DrugTender drugTender);
        public bool Delete(int id);
        public DrugTender GetByName(string name);
        public void Update(DrugTender drugTender);
    }
}
