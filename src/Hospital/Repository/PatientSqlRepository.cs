using Hospital.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Repository
{
    public class PatientSqlRepository : IPatientRepository
    {
        public MyDbContext dbContext { get; set; }

        public  PatientSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PatientSqlRepository() { }

        public List<Patient> GetAll()
        {
            return dbContext.Patients.ToList();
        }

        public Patient GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public void SavePatient(Patient patient)
        {
            dbContext.MedicalRecords.Add(new MedicalRecord { Id = patient.MedicalRecordId });
            Doctor d = (from n in dbContext.Doctors where n.Id == patient.DoctorId select n).FirstOrDefault();
            d.NumberOfPatients++;
            dbContext.Patients.Add(patient);
            dbContext.SaveChanges();
        }

        public bool Update(Patient editedObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Patient newObject)
        {
            throw new NotImplementedException();
        }
    }
}
