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
    [Trait("Type", "UnitTest")]
    public class MedicineSearchTests
    {
        [Theory]
        [MemberData(nameof(Searches))]
        public void Check_searched_medicine_by_name_and_substance(string search1, string search2, int expected)
        {
            //arrange
            var medicineService = new MedicineService(GenerateStubData());
            //act
            List<Medicine> retVal = medicineService.SearchMedicineByNameAndSubstance(search1, search2);
            //assert
            retVal.Count.ShouldBe(expected);
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

        private static IMedicineRepository GenerateStubData()
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();
            List<Medicine> searchedMedicines = new List<Medicine>();

            Medicine m1 = new Medicine(1, "Lek1", "paracetamol, kiselina");
            Medicine m2 = new Medicine(2, "Lek2", "kiselina2");
            Medicine m3 = new Medicine(3, "Lek3", "paracetamol, protein");

            searchedMedicines.Add(m1);
            searchedMedicines.Add(m2);
            searchedMedicines.Add(m3);

            medicineStubRepository.Setup(m => m.GetAll()).Returns(searchedMedicines);

            return medicineStubRepository.Object;
        }
    }
}
