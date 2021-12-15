﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hospital.Medicines.Model;
using Hospital.Medicines.Repository.Interfaces;
using Hospital.SharedModel;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Medicines.Repository.Sql
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

        public List<Medicine> GetAll()
        {            
            List<Medicine> result = new List<Medicine>();
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Medicine(medicine.Id, medicine.Name, medicine.Price, medicine.Supply,
                medicine.Manufacturer, medicine.SideEffects, medicine.Reactions, medicine.Usage, medicine.Weight, medicine.Precautions, medicine.MedicineImage)));

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
        public void Remove(Medicine medicine)
        {
            
            if (GetByName(medicine.Name) != null)
            {
                DbContext.Medicines.Remove(medicine);
                DbContext.SaveChanges();
            }
        }

    }
}
