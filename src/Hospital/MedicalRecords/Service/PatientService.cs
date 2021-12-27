using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Factory;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.SharedModel;
using Microsoft.IdentityModel.Tokens;

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
            PatientRepository = patientSqlRepository;
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
            PatientSqlRepository.SavePatient(newPatient);
        }

        public Patient FindByUsernameAndPassword(String username, String password)
        {
            return PatientRepository.FindByUsernameAndPassword(username, password);
        }

        public String GenerateJwtToken(Patient patient)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (patient.Username.Equals("manager") && patient.Password.Equals("manager"))
            {
                //logika za menadzera
                return "";
            }
            else
                return GenerateJwtTokenPatient(tokenHandler, patient);
            
        }

        public String GenerateJwtTokenPatient(JwtSecurityTokenHandler tokenHandler, Patient patient)
        {            
            SecurityTokenDescriptor tokenDeskriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", patient.Id.ToString()),
                    new Claim("role", "patient")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Ovde mora neki duzi kljuc da ide")), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDeskriptor);
            return tokenHandler.WriteToken(token);
        }

    }

}
