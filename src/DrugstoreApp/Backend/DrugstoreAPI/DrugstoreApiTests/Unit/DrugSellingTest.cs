using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using DrugstoreAPI.Controllers;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drugstore.Service;
using Xunit;

namespace DrugstoreApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class DrugSellingTest
    {
        [Theory]
        [MemberData(nameof(Medicines))]
        public void Drug_sell_with_Response(Medicine drug, bool expectedValue)
        {
            // arrange
            var medicineRepository = new Mock<IMedicineRepository>();
            var hospitalRepository = new Mock<IHospitalRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "DrugStoreSecretKey";

            var controler = new DrugDemandController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
            controler.HospitalService = new HospitalService(hospitalRepository.Object);
            controler.medicineService = new MedicineService(medicineRepository.Object);
            controler.mailService = new MailService(hospitalRepository.Object);

            medicineRepository.Setup(d => d.GetByName("Brufen")).Returns(drug);
            medicineRepository.Setup(d => d.GetByName(null)).Returns(drug);
            hospitalRepository.Setup(h => h.GetAll()).Returns(new List<Hospital>
            {
                new Hospital("", 111, "", "DrugStoreSecretKey", "nesto@gmail.com")
            });

            //act
            var result = controler.UrgentPurchase(new DrugAmountDemandDto("Brufen", 5)) as ObjectResult;

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
