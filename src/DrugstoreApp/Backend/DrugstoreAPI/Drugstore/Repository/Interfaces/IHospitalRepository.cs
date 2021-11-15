using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;

namespace Drugstore.Repository.Interfaces
{
    public interface IHospitalRepository
    {
        public List<Hospital> GetAll();
        public Hospital GetHospitalById(int id);
        public int GetIdByName(string name);
        public string GetKeyByName(string name);
        public void Save(Hospital newHospital);
    }
}
