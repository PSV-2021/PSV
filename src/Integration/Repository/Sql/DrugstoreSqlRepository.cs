using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.Model;
using Integration_API.Model;
using Integration_API.Repository.Interfaces;
using Model.DataBaseContext;

namespace Integration.Repository.Sql
{ 
    public class DrugstoreSqlRepository : IDrugstoreRepository
    {
        public MyDbContext dbContext { get; set; }

        public DrugstoreSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DrugstoreSqlRepository()
        {

        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drugstore> GetAll()
        {
            List<Drugstore> result = new List<Drugstore>();
            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url)));

            return result;
        }

        public string GetDrugstoreName(string id)
        {
            var query = from st in dbContext.Drugstores
                where st.Id == id.ToString()
                select st.Name;

            return query.FirstOrDefault();
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
