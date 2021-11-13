using System;
using System.Collections.Generic;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Xunit;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
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

        public static IEnumerable<object[]> Medicines()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Medicine(5, "Brufen", 500, 10), true });
            retVal.Add(new object[] { new Medicine(5, "Brufen", 500, 3), false });
            retVal.Add(new object[] { new Medicine(), false });
            return retVal;

        }

    }
}
