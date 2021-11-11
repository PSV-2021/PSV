using System;
using System.Collections.Generic;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Xunit;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
using Moq;

namespace DrugstoreApiTests
{
    public class DrugAvailabilityTests
    {
        [Fact]
        public void Certain_amount_of_drugs_is_available()
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();
            var drug = new Medicine(5, "Brufen", 500, 10);

            medicineStubRepository.Setup(d => d.GetByName("Brufen")).Returns(drug);

            MedicineService service = new MedicineService(medicineStubRepository.Object);

            bool retVal = service.CheckForAmountOfDrug("Brufen", 5);


            Assert.True(retVal);
        }

        [Fact]
        public void Certain_amount_of_drugs_is_not_available()
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();
            var drug = new Medicine(5, "Brufen", 500, 3);

            medicineStubRepository.Setup(d => d.GetByName("Brufen")).Returns(drug);

            MedicineService service = new MedicineService(medicineStubRepository.Object);

            bool retVal = service.CheckForAmountOfDrug("Brufen", 5);

            Assert.False(retVal);
        }

        [Fact]
        public void Certain_drug_is_not_available()
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();
            var drug = new Medicine();

            medicineStubRepository.Setup(d => d.GetByName("Paracetamol")).Returns(drug);

            MedicineService service = new MedicineService(medicineStubRepository.Object);

            bool retVal = service.CheckForAmountOfDrug("Brufen", 5);

            Assert.False(retVal);
        }

    }
}
