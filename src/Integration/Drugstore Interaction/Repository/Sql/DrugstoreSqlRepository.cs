using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.Model;
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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drugstore> GetAll()
        {
            List<Drugstore> result = new List<Drugstore>();

            dbContext.Drugstores.ToList().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url, drugstore.ApiKey, drugstore.Email, drugstore.City,drugstore.Address, drugstore.Comment, drugstore.Base64Image)));

            return result;
        }

        public string GetDrugstoreName(int id)
        {
            var query = from st in dbContext.Drugstores
                        where st.Id == id
                        select st.Name;

            return query.FirstOrDefault();
        }

        public Drugstore GetOne(int id)
        {
            return dbContext.Drugstores.Find(id);
        }

        public void Save(Drugstore newObject)
        {
            dbContext.Add(newObject);
            dbContext.SaveChanges();
        }

        public void Update(Drugstore editedObject)
        {
            dbContext.Drugstores.Update(editedObject);
            dbContext.SaveChanges();
        }

        public List<Drugstore> SearchDrugstoresByCityAndAddress(string city, string address)
        {
            var retVal = dbContext.Drugstores.Where(drugstore => 
                drugstore.City.Contains(city) && drugstore.Address.Contains(address)
                ).ToList();
            return retVal;
        }
    }
}
