using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugstoreAPI.Models;
using Model.DataBaseContext;

namespace DrugstoreAPI.Repository
{
    public class HospitalSqlRepository
    {
        public MyDbContext dbContext { get; set; }

        public HospitalSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Hospital> GetAll()
        {
            List<Hospital> result = dbContext.Hospitals.ToList();
            return result;
        }

        public HospitalSqlRepository()
        {

        }
        public bool GetHospitalById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            foreach (Hospital hs in dbContext.Hospitals.ToList())
            {
                if (hs.Name.Equals(name))
                {
                    return hs.Id;
                }
            }

            return 0;
        }

        public string GetKeyByName(string name)
        {
            foreach (Hospital hs in dbContext.Hospitals.ToList())
            {
                if (hs.Name.Equals(name))
                {
                    return hs.ApiKey;
                }
            }

            return "";
        }
    }
}
