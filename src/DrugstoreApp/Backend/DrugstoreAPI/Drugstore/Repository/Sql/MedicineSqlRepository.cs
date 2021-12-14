﻿using Drugstore.Models;
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
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Medicine(medicine.Id, medicine.Name, medicine.Price, medicine.Supply, medicine.Manufacturer, medicine.SideEffects,
                                                                medicine.Reactions, medicine.Usage, medicine.CompatibleMedicines, medicine.Weight, medicine.Precautions, medicine.Substances)));

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

        public Medicine GetByName1(string name)
        {
            Medicine medicine = DbContext.Medicines.FirstOrDefault(medicine => medicine.Name == name);
            return medicine;
        }

        public void Update(Medicine medicine)
        {
            DbContext.Medicines.Update(medicine);
            DbContext.SaveChanges();
        }
    }
}
