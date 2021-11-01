using System;
using System.Collections.Generic;
using System.Text;
using Integration.Model;
using Integration.Repository.Interfaces;

namespace Integration.Repository.Sql
{
    class DrugstoreSqlRepository : IDrugstoreRepository
    {
        private string ConnectionString = "";

        public DrugstoreSqlRepository(string cs)
        {
            ConnectionString = cs;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drugstore> GetAll()
        {
            throw new NotImplementedException();
        }

        public Drugstore GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Drugstore newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Drugstore editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
