using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using AutoFixture;
using RichardSzalay.MockHttp;
using System.Net.Http;
using System.Net;
using Moq;
using Moq.Protected;
using System.Threading;
using Hospital.MedicalRecords.Service;
using Shouldly;
using HospitalAPI.DTO;
using HospitalAPI.Verification;
using Hospital.SharedModel;
using Hospital.MedicalRecords.Model;

namespace HospitalApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class PatientRegistrationTests
    {
        private PatientVerification patientVerification = new PatientVerification();
        [Fact]
        public async Task GetStringAsync_uses_HttpClient_to_get_content_from_given_URI()
        {
            // ARRANGE
            var fixture = new Fixture();
            var testUri = fixture.Create<Uri>();
            var expectedResult = fixture.Create<string>();
            var handler = new MockHttpMessageHandler();
            handler.When(HttpMethod.Get, testUri.ToString())
                   .Respond(HttpStatusCode.OK, new StringContent(expectedResult));
            var http = handler.ToHttpClient();
            var sut = new PatientDataService(http);
            // ACT
            var result = await sut.GetStringAsync(testUri);
            // ASSERT
            Assert.Equal(result, expectedResult);
        }
        [Fact]
        public async Task Post_request_uses_HttpClient()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{'jmbg':'3009998805137','name':'Masa'}]"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://localhost:5000/"),
            };

            var subjectUnderTest = new PatientDataService(httpClient);

            // ACT
            var result = await subjectUnderTest
               .GetSomethingRemoteAsync("api/test/whatever");

            // ASSERT
            result.ShouldNotBeNull();

            var expectedUri = new Uri("http://localhost:5000/api/test/whatever");

            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1), // we expected a single external request
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Post // we expected a GET request
                  && req.RequestUri == expectedUri // to this uri
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }
        [Fact]
        public void Check_patient_name_true()
        {
            PatientDto patient = GeneratePatient();
            Assert.True(patientVerification.Verify(patient));
        }
        [Fact]
        public void Check_patient_surname_null()
        {
            PatientDto patient = GeneratePatient();
            patient.Surname = null;
            Assert.False(patientVerification.Verify(patient));
        }
        [Fact]
        public void Check_patient_name_false()
        {
            PatientDto patient = GeneratePatient();
            patient.Name = "milan";
            Assert.False(patientVerification.Verify(patient));
        }
        [Fact]
        public void Check_patient_address_true()
        {
            PatientDto patient = GeneratePatient();
            Assert.True(patientVerification.Verify(patient));
        }
        [Fact]
        public void Check_patient_email_false()
        {
            PatientDto patient = GeneratePatient();
            patient.Email = "nesto";
            Assert.False(patientVerification.Verify(patient));
        }
        private PatientDto GeneratePatient()
        {
            return new PatientDto { Name = "Mirko", FathersName = "Srdjan", Surname = "Kitic", Jmbg = "3009998805057", Date = "20/01/2000 00:00:00", Sex = Sex.male, PhoneNumber = "0641664608", Address = "Resavska 5", Email = "mirko@gmail.com", Username = "uproba", Password = "pproba", BloodType = BloodType.A, DoctorId = 1, Allergens = new List<String>() };
        }
    }
}
