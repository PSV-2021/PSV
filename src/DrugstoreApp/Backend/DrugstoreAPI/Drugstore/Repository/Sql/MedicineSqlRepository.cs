using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Sql
{
    public class MedicineSqlRepository:IMedicineRepository
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
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Medicine(medicine.Id, medicine.Name, medicine.Price)));

            return result;
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
    }
}
