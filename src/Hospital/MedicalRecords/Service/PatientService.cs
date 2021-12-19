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
        private Patient patient = new Patient();


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
            
            List<Patient> patients = PatientRepository.GetAll().ToList();
            
            return patient.IdEqual(patients, id);
        }

        public PatientService(PatientSqlRepository patientSqlRepository)
        {
            PatientSqlRepository = patientSqlRepository;
            AllergenRepository = new AllergenSqlRepository();
        }

        public Patient GetPatientById(int id)
        {
            return PatientSqlRepository.GetOne(id);
        }

        public List<Patient> GetAllPatients()
        {
            return PatientRepository.GetAll();
        }

        public List<string> GetAllergensById(int id)
        {
            return AllergenRepository.GetByIdPatient(id);
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
