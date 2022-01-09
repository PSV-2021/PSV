using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;
using System;
using System.Collections.Generic;

namespace Hospital.MedicalRecords.Repository
{
    public interface IPatientRepository:IGenericRepository<Patient, string>
    {
        public List<Patient> GetAll();
        public Patient FindByUsernameAndPassword(String username, String password);
    }
}
