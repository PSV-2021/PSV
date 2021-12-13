using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.MedicalRecords.Service;
using Xunit;

namespace HospitalApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class SurveyUnitTests
    {
        [Trait("Type", "UnitTest")]

        [Theory]
        [MemberData(nameof(Data))]
        public void Appointment_id_exist_or_doesnt_exist(int id, bool expectedValue)
        {
            var surveyStubRepository = new Mock<ISurveyRepository>();
            var surveyService = new SurveyService(surveyStubRepository.Object);
            List<Survey> survey = GenerateStubData();

            surveyStubRepository.Setup(s => s.GetAll()).Returns(survey);

            SurveyService service = new SurveyService(surveyStubRepository.Object);
            bool b = service.CheckIfExistsById(id);

            b.ShouldBe(expectedValue);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, true });
            retVal.Add(new object[] { 3, false });
            return retVal;

        }

        private static List<Survey> GenerateStubData()
        {
            List<Survey> surveys = new List<Survey>();
            
            Survey survey1 = new Survey(1, DateTime.Now, 1);
            Survey survey2 = new Survey(1, DateTime.Now, 2);

            surveys.Add(survey1);
            surveys.Add(survey2);
            

            return surveys;
        }

    }
}
