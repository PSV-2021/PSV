using Hospital.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Repository
{
    public class IngredientSqlRepository : IIngredientRepository
    {
        private MyDbContext context;

        public IngredientSqlRepository(MyDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ingridient> GetAll()
        {
            List<Ingridient> result = new List<Ingridient>();
            context.Ingridients.ToList().ForEach(ingredients => result.Add(ingredients));

            return result;
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
