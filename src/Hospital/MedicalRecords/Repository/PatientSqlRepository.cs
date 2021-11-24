using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Repository
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

        public Patient GetOne(int id)
        {
            Console.WriteLine(id+ "u getone");
            Patient patientWithThatId = (from n in dbContext.Patients where n.Id == id select n).FirstOrDefault();
            return patientWithThatId;
        }

        internal int FindIdMedRecordByIdPatient(int idPatient)
        {
           return (from n in dbContext.Patients where n.Id == idPatient select n).FirstOrDefault().MedicalRecordId;
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

        public bool activateAccount(int userId, string token)
        {
            Patient patientToChange = dbContext.Patients.Find(userId);
            if (patientToChange.Token.Equals(token))
            {
                patientToChange.IsActive = true;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool saveToken(Patient tokenPatient)
        {
            Patient patientToChange = dbContext.Patients.Find(tokenPatient.Id);
            patientToChange.Token = tokenPatient.Token;
            dbContext.SaveChanges();
            return true;
        }

        public bool CheckToken(string token)
        {
            try
            {
                Patient patientToChange = (from n in dbContext.Patients where n.IsActive!=true && n.Token == token select n).First();
                if (patientToChange != null)
                {
                    patientToChange.IsActive = true;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;

            }

            return false;
        }
    }
}
