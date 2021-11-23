using Integration.Model;
using Integration.Repository.Interfaces;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Sql
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
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Medicine(medicine.Id, medicine.Name)));

            return result;
        }

        public Medicine GetByName(string name)
        {
            return DbContext.Medicines.Where(m => m.Name == name).FirstOrDefault<Medicine>();
        }

        public void Update(Medicine medicine)
        {
            DbContext.Medicines.Update(medicine);
            DbContext.SaveChanges();
        }
        public void Save(Medicine newMedicine)
        {
            try
            {
                DbContext.Medicines.Add(newMedicine);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
