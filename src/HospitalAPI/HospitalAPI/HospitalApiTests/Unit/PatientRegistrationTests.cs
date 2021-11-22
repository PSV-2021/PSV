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

namespace HospitalApiTests.Unit
{
    public class PatientRegistrationTests
    {
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
        /*[Fact]
        public void Save_Patient()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            var patient = new Patient("Marko", "Petar", "Markovic", "3009998805137", new DateTime(2001, 1, 1), Sex.male, "0641664608", "Resavska 5", "marko.markovic@gmail.com", null, "uproba", "pproba", BloodType.A, false, null, false);

            patientStubRepository.Setup(r => r.Save(patient)).Returns(patient);

            PatientService patientService = new PatientService(patientStubRepository.Object, null);

            Patient p = patientService.Save(patient);
            Assert.Null(p);

        }*/
    }
}
