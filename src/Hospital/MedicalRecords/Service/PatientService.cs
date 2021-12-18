using System;
using System.Collections.Generic;
using System.Linq;
using Factory;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Service
{
    public class PatientService
    {
        private IPatientRepository PatientRepository { get; }
        private PatientSqlRepository PatientSqlRepository { get; set; }
        private MedicalRecordSqlRepository MedicalRecordRepository { get; set; }
        public AllergenSqlRepository AllergenRepository { get; set; }
        private IRepositoryFactory RepositoryFactory { get; }


        public PatientService(IPatientRepository patientRepository)
        {
            PatientRepository = patientRepository;
        }

        public PatientService(AllergenSqlRepository allergenSqlRepository)
        {
            PatientRepository = new PatientSqlRepository();
            PatientSqlRepository = new PatientSqlRepository();
            AllergenRepository = allergenSqlRepository;

        }
        public PatientService()
        {
            PatientRepository = new PatientSqlRepository();
            PatientSqlRepository = new PatientSqlRepository();
            AllergenRepository = new AllergenSqlRepository();

        }


        public bool CheckIfExistsById(int id)
        {
            bool retVal = false;
            List<Patient> patients = PatientRepository.GetAll().ToList();
            foreach (Patient patient in patients)
            {
                if (patient.Id == id)
                    retVal = true;

            }
            return retVal;
        }

        public PatientService(PatientSqlRepository patientSqlRepository)
        {
            PatientSqlRepository = patientSqlRepository;
            AllergenRepository = new AllergenSqlRepository();
        }

        public Patient GetPatientById(int id)
        {
            Patient patientFound = PatientSqlRepository.GetOne(id);
            return patientFound;
        }

        public List<Patient> GetAllPatients()
        {
            return PatientRepository.GetAll();
        }

        public List<string> GetAllergensById(int id)
        {
            List<string> allergensOfPatient = AllergenRepository.GetByIdPatient(id);
            return allergensOfPatient;

        }

        public void SavePatientSql(Patient newPatient, MyDbContext context)
        {
           GenerateMedicalRecordId(newPatient, context);
           PatientSqlRepository.SavePatient(newPatient);
        }

        public void GenerateMedicalRecordId(Patient p, MyDbContext context)
        {
            MedicalRecordRepository = new MedicalRecordSqlRepository(context);
            List<Model.MedicalRecord> mr = MedicalRecordRepository.GetAll();
            p.MedicalRecordId = (mr.Count + 1);
        }

    }

}
