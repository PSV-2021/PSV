using Integration.Model;
using Integration.Repository.Interfaces;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Sql
{
    public class DrugSqlRepository : IDrugRepository
    {
        public MyDbContext DbContext { get; set; }

        public DrugSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public DrugSqlRepository()
        {
        }

        public List<Drug> GetAll()
        {
            List<Drug> result = new List<Drug>();
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Drug(medicine.Id, medicine.Name)));

            return result;
        }

        public Drug GetByName(string name)
        {
            return DbContext.Medicines.Where(m => m.Name == name).FirstOrDefault<Drug>();
        }

        public void Update(Drug medicine)
        {
            DbContext.Medicines.Update(medicine);
            DbContext.SaveChanges();
        }
        public void Save(Drug newMedicine)
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
        public void Remove(Drug medicine)
        {
            if(GetByName(medicine.Name) != null)
            {
                DbContext.Medicines.Remove(medicine);
                DbContext.SaveChanges();
            }
        }
    }
}
