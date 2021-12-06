using System;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Hospital.MedicalRecords.Model;

namespace HospitalApiTests.Unit
{
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

            Patient patient1 = new Patient { Name = "Nikola", Id = 12 };
            Patient patient2 = new Patient { Name = "Nikolina", Id = 13};

            patients.Add(patient1);
            patients.Add(patient2);

            return patients;
        }
    }
}
