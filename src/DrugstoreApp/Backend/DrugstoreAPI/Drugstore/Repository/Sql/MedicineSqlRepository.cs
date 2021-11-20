using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Sql
{
    public class MedicineSqlRepository : IMedicineRepository
    {
        public MyDbContext DbContext { get; set; }

        public MedicineSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public MedicineSqlRepository()
        {
        }

        public List<Medicine> GetAll()
        {
            List<Medicine> result = new List<Medicine>();
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Medicine(medicine.Id, medicine.Name, medicine.Price, medicine.Supply)));

            return result;
        }

        public Medicine GetOne(int id)
        {
            Medicine medicine = DbContext.Medicines.FirstOrDefault(medicine => medicine.Id == id);
            return medicine;
        }

        public void Add(Medicine medicine)
        {
            int id = DbContext.Medicines.ToList().Count > 0 ? DbContext.Medicines.ToList().Max(medicine => medicine.Id) + 1 : 1;
            medicine.Id = id;
            DbContext.Medicines.Add(medicine);
            DbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            Medicine medicine = DbContext.Medicines.ToList().Find(medicine => medicine.Id == id);
            if (medicine == null)
                return false;
            else
            {
                DbContext.Medicines.Remove(medicine);
                DbContext.SaveChanges();
                return true;
            }
        }
        public Medicine GetByName(string name)
        {
            return DbContext.Medicines.Where(m => m.Name == name).FirstOrDefault<Medicine>();
        }

        public void Update(Medicine med)
        {
            DbContext.Medicines.Update(med);
            DbContext.SaveChanges();
        }

        public List<Medicine> SearchMedicineByNameAndSubstance(string name, string substance)
        {
            var retVal = DbContext.Medicines.Where(medicine => medicine.Name.Contains(name) && medicine.Substances.Contains(substance)).ToList();
            return retVal;
        }
    }
}
