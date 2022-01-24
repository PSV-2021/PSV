using Integration_API.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Integration.Drugstore_Interaction.Model.ValueObjects;
using Integration.Model;
using Integration.Service;
using Integration_API.Controllers;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class DrugstoreSearchTests
    {
        [Fact]
        public void Check_searched_drugstore_by_city_and_adress()
        {
            var drugstoreStubRepository = new Mock<IDrugstoreRepository>();
            var drugstoreService = new DrugstoreService(drugstoreStubRepository.Object);
            List<Drugstore> seachedDrugstores = GenerateStubData();

            drugstoreStubRepository.Setup(dr => dr.SearchDrugstoresByCityAndAddress("Novi Sad", "")).Returns(seachedDrugstores);

            List<Drugstore> retVal = drugstoreService.SearchDrugstoresByCityAndAddress("Novi Sad", "");
            
            retVal.Count.ShouldBe(3);
        }

        [Theory]
        [MemberData(nameof(Searches))]
        public void Drugstore_search_with_response(string city, string address, int expectedValue)
        {
            var drugstoreRepository = new Mock<IDrugstoreRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";
            List<Drugstore> retVal = GenerateStubData();

            var controler = new DrugstoreController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            controler.drugstoreService = new DrugstoreService(drugstoreRepository.Object);
            drugstoreRepository.Setup(dr => dr.SearchDrugstoresByCityAndAddress(city, address)).Returns(retVal);

            var result = controler.Filter(city, address) as ObjectResult;

            result.ShouldNotBeNull();
            retVal = (List<Drugstore>)result.Value;
            retVal.Count.ShouldBe(expectedValue);

        }

        [Fact]
        public void Check_if_ApiKey_is_not_valid()
        {
            var drugstoreRepository = new Mock<IDrugstoreRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "something wrong";
            List<Drugstore> retVal = GenerateStubData();

            var controler = new DrugstoreController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            controler.drugstoreService = new DrugstoreService(drugstoreRepository.Object);
            drugstoreRepository.Setup(dr => dr.SearchDrugstoresByCityAndAddress("", "")).Returns(retVal);

            var result = controler.Filter("", "");

            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        private static List<Drugstore> GenerateStubData()
        {
            List<Drugstore> seachedDrugstores = new List<Drugstore>();

            Drugstore drugstore1 = new Drugstore(1, "Apoteka prva", "http://localhost:5001", "aaabbbccc",
                new Email("apoteka1@gmail.com"), "Srbija","Novi Sad", "some address", true);
            Drugstore drugstore2 = new Drugstore(2, "Apoteka druga", "http://localhost:5001", "aaabbbccc",
                new Email("apoteka1@gmail.com"), "Srbija","Novi Sad", "some address", false);
            Drugstore drugstore3 = new Drugstore(3, "Apoteka treca", "http://localhost:5001", "aaabbbccc",
                new Email("apoteka1@gmail.com"), "Srbija","Novi Sad", "some address", false);

            seachedDrugstores.Add(drugstore1);
            seachedDrugstores.Add(drugstore2);
            seachedDrugstores.Add(drugstore3);
            return seachedDrugstores;
        }

        public static IEnumerable<object[]> Searches()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Novi Sad", "some", 3 });
            retVal.Add(new object[] { "Novi Sad", "", 3 });
            retVal.Add(new object[] { "", "", 3 });
            return retVal;

        }
    }
}
