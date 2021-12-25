using System;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace HospitalApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class MedicalRecordTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Record_id_exist_or_doesnt_exist(int id, bool expectedValue)
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            var patientService = new PatientService(patientStubRepository.Object);
            List<Patient> patients = GenerateStubData();

            patientStubRepository.Setup(s => s.GetAll()).Returns(patients);

            PatientService service = new PatientService(patientStubRepository.Object);
            bool b = service.CheckIfExistsById(id);

            b.ShouldBe(expectedValue);
        }
        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 12, true });
            retVal.Add(new object[] { 3, false });
            return retVal;

        }
        private static List<Patient> GenerateStubData()
        {
            List<Patient> patients = new List<Patient>();
          
            Patient patient1 = new Patient(12, "Andjelka", "Andjic", "andji", "andji", "1821099320191", new DateTime(1980, 9, 17), BloodType.A,
                "Milan", Sex.female, "02102019", "Resavska 1", "andja12@gmail.com");
            Patient patient2 = new Patient(13, "Milica", "Andjic", "andji", "andji", "1821099320191", new DateTime(1980, 9, 17), BloodType.A,
                "Milan", Sex.female, "02102019", "Resavska 1", "andja12@gmail.com");

            patients.Add(patient1);
            patients.Add(patient2);

            return patients;
        }
    }
}
