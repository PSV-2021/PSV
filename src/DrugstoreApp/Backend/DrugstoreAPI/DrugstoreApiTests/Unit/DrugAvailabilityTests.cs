using System;
using System.Collections.Generic;
using System.Net.Http;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Xunit;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Controllers;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace DrugstoreApiTests
{
    public class DrugAvailabilityTests
    {
        [Theory]
        [MemberData(nameof(Medicines))]
        public void Certain_drugs_availability(Medicine drug, bool expectedValue)
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();

            medicineStubRepository.Setup(d => d.GetByName("Brufen")).Returns(drug);

            MedicineService service = new MedicineService(medicineStubRepository.Object);

            bool retVal = service.CheckForAmountOfDrug("Brufen", 5);

            retVal.ShouldBe(expectedValue);
        }

        [Theory]
        [MemberData(nameof(Medicines))]
        public void Drugs_availability_with_Response(Medicine drug, bool expectedValue)
        {
            // arrange
            var medicineRepository = new Mock<IMedicineRepository>();
            var hospitalRepository = new Mock<IHospitalRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "DrugStoreSecretKey";

            var controler = new DrugDemandController(medicineRepository.Object, hospitalRepository.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            medicineRepository.Setup(d => d.GetByName("Brufen")).Returns(drug);
            medicineRepository.Setup(d => d.GetByName(null)).Returns(drug);
            hospitalRepository.Setup(h => h.GetAll()).Returns(new List<Hospital>
            {
                new Hospital("", 111, "", "DrugStoreSecretKey")
            });

            //act
            var result = controler.Post(new DrugAmountDemandDto("Brufen", 5)) as ObjectResult;

            //assert
            result.ShouldNotBeNull();
            result.Value.ShouldBe(expectedValue);

        }

        public static IEnumerable<object[]> Medicines()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Medicine(5, "Brufen", 500, 3), false });
            retVal.Add(new object[] { new Medicine(5, "Brufen", 500, 10), true });
            retVal.Add(new object[] { new Medicine(), false });
            return retVal;

        }
    }
}
