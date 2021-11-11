using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;

namespace Drugstore.Repository.Interfaces
{
    public interface IHospitalRepository
    {
        public List<Hospital> GetAll();
        public bool GetHospitalById(int id);
        public int GetIdByName(string name);
        public string GetKeyByName(string name);
        public bool Save(Hospital newHospital);
    }
}
