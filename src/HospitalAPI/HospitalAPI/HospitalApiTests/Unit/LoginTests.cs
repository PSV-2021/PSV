using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.SharedModel;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class LoginTests
    {
        [Fact]
        public void Patient_username_and_password_exist()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            var patientService = new PatientService(patientStubRepository.Object);
            List<Patient> patients = GenerateStubData();

            patientStubRepository.Setup(s => s.GetAll()).Returns(patients);

            PatientService service = new PatientService(patientStubRepository.Object);
            Patient b = service.FindByUsernameAndPassword("miki98", "miki985");

            b.ShouldBeNull();
        }

        [Fact]
        public void Patient_username_and_password_doesnt_exist()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            var patientService = new PatientService(patientStubRepository.Object);
            List<Patient> patients = GenerateStubData();

            patientStubRepository.Setup(s => s.GetAll()).Returns(patients);

            PatientService service = new PatientService(patientStubRepository.Object);
            Patient b = service.FindByUsernameAndPassword("nesto", "nesto");

            b.ShouldBeNull();
        }


        private static List<Patient> GenerateStubData()
        {
            List<Patient> patients = new List<Patient>();

            Patient patient1 = new Patient(1, "Marko", "Markovic", "3009998805138", new DateTime(1998, 06, 25), Sex.male, "0641664608",
                "Bulevar Oslobodjenja 8", "marko@gmail.com", "miki98", "miki985", true, BloodType.B, "Petar", 1, new List<Allergen>());
            Patient patient2 = new Patient(2, "Milica", "Mikic", "3009998805137", new DateTime(1997, 10, 12), Sex.female, "065245987", "Kisacka 5", "milica@gmail.com",
               "mici97", "mici789", true, BloodType.A, "Nenad", 1, new List<Allergen>());

            patients.Add(patient1);
            patients.Add(patient2);


            return patients;
        }
    }
}
