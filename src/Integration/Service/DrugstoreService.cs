using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Factory;
using Integration.Model;
using Integration.Repository.Sql;
using Integration_API.Repository.Interfaces;
using Model.DataBaseContext;
using Npgsql;


namespace Integration.Service
{
   public class DrugstoreService
    {
        public IDrugstoreRepository DrugstoreRepository { get; }

        public DrugstoreService()
        {
            DrugstoreRepository = new DrugstoreSqlRepository();
        }

        public DrugstoreService(IDrugstoreRepository drugstoreRepository)
        {
            DrugstoreRepository = drugstoreRepository;
        }

        public string GetDrugStoreURL(int id,MyDbContext dbContext)
        {
            foreach (Drugstore dg in dbContext.Drugstores.ToList())
            {
                if (dg.Id == id)
                {
                    return dg.Url;
                }
            }

            return null;
        }

        public List<Drugstore> SearchDrugstoresByCityAndAddress(string city, string address)
        {
            return DrugstoreRepository.SearchDrugstoresByCityAndAddress(city, address);
        }
    }
}
