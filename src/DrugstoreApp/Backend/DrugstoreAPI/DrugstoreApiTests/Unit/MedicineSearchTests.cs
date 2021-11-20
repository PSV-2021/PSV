using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using DrugstoreAPI.Controllers;
using DrugstoreAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DrugstoreApiTests.Unit
{
    public class MedicineSearchTests
    {
        [Fact]
        public void Check_searched_medicine_by_name_and_substance()
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();
            var medicineService = new MedicineService(medicineStubRepository.Object);
            List<Medicine> seachedMedicines = GenerateStubData();

            medicineStubRepository.Setup(m => m.SearchMedicineByNameAndSubstance("", "")).Returns(seachedMedicines);

            List<Medicine> retVal = medicineService.SearchMedicineByNameAndSubstance("", "");

            retVal.Count.ShouldBe(3);
        }

        [Theory]
        [MemberData(nameof(Searches))]
        public void Medicine_search_with_response(string name, string substance, int expectedValue)
        {
            var medicineRepository = new Mock<IMedicineRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";
            List<Medicine> retVal = GenerateStubData();

            var controler = new MedicineController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            controler.medicineService = new MedicineService(medicineRepository.Object);
            medicineRepository.Setup(dr => dr.SearchMedicineByNameAndSubstance(name, substance)).Returns(retVal);

            var result = controler.Filter(name, substance) as ObjectResult;

            result.ShouldNotBeNull();
            retVal = (List<Medicine>)result.Value;
            retVal.Count.ShouldBe(expectedValue);

        }

        [Fact]
        public void Check_if_ApiKey_is_not_valid()
        {
            var medicineRepository = new Mock<IMedicineRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "something wrong";
            List<Medicine> retVal = GenerateStubData();

            var controler = new MedicineController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            controler.medicineService = new MedicineService(medicineRepository.Object);
            medicineRepository.Setup(dr => dr.SearchMedicineByNameAndSubstance("", "")).Returns(retVal);

            var result = controler.Filter("", "");

            Assert.IsType<UnauthorizedResult>(result);
        }

        private static List<Medicine> GenerateStubData()
        {
            List<Medicine> searchedMedicines = new List<Medicine>();

            Medicine m1 = new Medicine(1, "Lek1", "paracetamol, kiselina");
            Medicine m2 = new Medicine(2, "Lek2", "kiselina2");
            Medicine m3 = new Medicine(3, "Lek3", "paracetamol, protein");

            searchedMedicines.Add(m1);
            searchedMedicines.Add(m2);
            searchedMedicines.Add(m3);
            return searchedMedicines;
        }
        public static IEnumerable<object[]> Searches()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Lek1", "", 1 });
            retVal.Add(new object[] { "", "paracetamol", 2 });
            retVal.Add(new object[] { "", "", 3 });
            retVal.Add(new object[] { "lek2", "protein", 0 });
            retVal.Add(new object[] { "Probiotik", "mlecno-kiselinska bakterija", 0 });
            retVal.Add(new object[] { "", "kiselina", 2 });
            return retVal;
        }
    }
}
