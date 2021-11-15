using Integration_API.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Integration.Model;
using Integration.Service;
using Shouldly;
using Xunit;

namespace IntegrationApiTests
{
    public class DrugstoreSearchTests
    {
        [Fact]
        public void check_searched_drugstore_by_city_and_adress()
        {
            var drugstoreStubRepository = new Mock<IDrugstoreRepository>();
            var drugstoreService = new DrugstoreService(drugstoreStubRepository.Object);
            List<Drugstore> seachedDrugstores = GenerateStubData();

            drugstoreStubRepository.Setup(dr => dr.SearchDrugstoresByCityAndAddress("Novi Sad", "")).Returns(seachedDrugstores);

            List<Drugstore> retVal = drugstoreService.SearchDrugstoresByCityAndAddress("Novi Sad", "");
            
            retVal.Count.ShouldBe(3);
        }

        private static List<Drugstore> GenerateStubData()
        {
            List<Drugstore> seachedDrugstores = new List<Drugstore>();

            Drugstore drugstore1 = new Drugstore(1, "Apoteka prva", "http://localhost:5001", "aaabbbccc",
                "apoteka1@gmail.com", "Novi Sad", "some address");
            Drugstore drugstore2 = new Drugstore(2, "Apoteka druga", "http://localhost:5001", "aaabbbccc",
                "apoteka1@gmail.com", "Novi Sad", "some address");
            Drugstore drugstore3 = new Drugstore(3, "Apoteka treca", "http://localhost:5001", "aaabbbccc",
                "apoteka1@gmail.com", "Novi Sad", "some address");

            seachedDrugstores.Add(drugstore1);
            seachedDrugstores.Add(drugstore2);
            seachedDrugstores.Add(drugstore3);
            return seachedDrugstores;
        }
    }
}
