using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class SpecialtySqlRepository : ISpecialtyRepository
    {
        private MyDbContext context;

        public SpecialtySqlRepository(MyDbContext context)
        {
            this.context = context;
        }

        public SpecialtySqlRepository() { }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Speciality> GetAll()
        {
            return context.Speciality.ToList();
        }

        public Speciality GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Speciality newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Speciality editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
