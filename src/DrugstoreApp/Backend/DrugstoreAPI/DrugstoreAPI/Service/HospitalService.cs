using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrugstoreAPI.Models;
using Integration.Repository.Sql;
using Drugstore.Models;
using DrugstoreAPI.Repository;

namespace Service
{
    public class HospitalService
    {
        public HospitalSqlRepository HospitalRepository { get; set; }

        public HospitalService(MyDbContext dbContext)
        {
            HospitalRepository = new HospitalSqlRepository();
            HospitalRepository.dbContext = dbContext;
        }

        public HospitalService()
        {
            HospitalRepository = new HospitalSqlRepository();
        }

        public int GetMaxId()
        {
            int max = -999;
            foreach (Hospital h in HospitalRepository.GetAll())
            {
                if (h.Id > max)
                    max = h.Id;
            }
            return max;
        }
    }
}
