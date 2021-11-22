using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Repository
{
    public class IngredientSqlRepository : IIngredientRepository
    {
        public MyDbContext context { get; set; }

        public IngredientSqlRepository(MyDbContext context)
        {
            this.context = context;
        }
        public IngredientSqlRepository() { }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ingridient> GetAll()
        {
            return context.Ingridients.ToList(); ;
        }

        public Ingridient GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Ingridient newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ingridient editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
