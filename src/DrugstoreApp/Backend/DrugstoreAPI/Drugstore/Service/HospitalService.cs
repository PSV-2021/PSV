using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;

namespace Service
{
    public class HospitalService
    {
        public IHospitalRepository HospitalRepository { get; set; }

        public HospitalService(IHospitalRepository hospitalRepository)
        {
            HospitalRepository = hospitalRepository;
        }

        public HospitalService()
        {
            HospitalRepository = new HospitalSqlRepository();
        }

        public HospitalService(HospitalSqlRepository hospitalSqlRepository)
        {
            HospitalRepository = hospitalSqlRepository;
        }


        public void SaveNewHospital(Hospital newHospital)
        {
            HospitalRepository.Save(newHospital);
        }

        public bool CheckApiKey(string apiKey)
        {
            bool found = false;
            foreach (Hospital h in HospitalRepository.GetAll())
            {
                if (h.ApiKey.Equals(apiKey))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
