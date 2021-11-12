using System;
using System.Collections.Generic;
using System.Linq;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Sql
{
    public class HospitalSqlRepository: IHospitalRepository
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
        public Hospital GetHospitalById(int id)
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

        public void Save(Hospital newHospital)
        {
            try
            {
                dbContext.Hospitals.Add(newHospital);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
