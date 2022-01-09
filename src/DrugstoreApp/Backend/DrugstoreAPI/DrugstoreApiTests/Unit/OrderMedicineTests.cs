using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Service;
using DrugstoreAPI.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DrugstoreApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class OrderMedicineTests
    {
        [Xunit.Theory]
        [NUnit.Framework.Theory]
        [MemberData(nameof(Orders))]
        public void Check_finnished_order(ShoppingCart order, List<int> expectedCount)
        {
            //arrange
            var medicineService = new MedicineService(GenerateStubDataMedicine(), GenerateStubDataOrder());
            //act
            medicineService.FinishOrder(order);
            //assert
            List<int> retVal = new List<int>();
            foreach(ShoppingCartItem item in order.ShoppingCartItems)
            {
                retVal.Add(medicineService.GetByName1(item.MedicineName).Supply);
            }
            CollectionAssert.AreEqual(expectedCount, retVal);
        }

        public static IEnumerable<object[]> Orders()
        {
            List<ShoppingCartItem> items1 = new List<ShoppingCartItem>();
            ShoppingCartItem item1 = new ShoppingCartItem("Brufen", 10);
            ShoppingCartItem item2 = new ShoppingCartItem("Paracetamol", 8);         
            items1.Add(item1);
            items1.Add(item2);

            List<int> retvalValues1 = new List<int>();
            retvalValues1.Add(5);
            retvalValues1.Add(3);

            //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            List<ShoppingCartItem> items2 = new List<ShoppingCartItem>();
            ShoppingCartItem item21 = new ShoppingCartItem("Brufen", 2);
            items2.Add(item21);

            List<int> retvalValues2 = new List<int>();
            retvalValues2.Add(13);

            var retVal = new List<object[]>();
            retVal.Add(new object[] { new ShoppingCart(1, items1, 350.00, OrderType.Delivery, false, false), retvalValues1});
            retVal.Add(new object[] { new ShoppingCart(1, items2, 400.00, OrderType.Pickup, false, false), retvalValues2});
            return retVal;
        }

        private static IMedicineRepository GenerateStubDataMedicine()
        {
            var medicineStubRepository = new Mock<IMedicineRepository>();
            List<Medicine> orderedMedicines = new List<Medicine>();

            Medicine m1 = new Medicine(1, "Brufen", 150.00, 15);
            Medicine m2 = new Medicine(2, "Paracetamol", 100.00, 11);

            orderedMedicines.Add(m1);
            orderedMedicines.Add(m2);

            medicineStubRepository.Setup(m => m.GetAll()).Returns(orderedMedicines);
            medicineStubRepository.Setup(m => m.GetByName1("Paracetamol")).Returns(m2);
            medicineStubRepository.Setup(m => m.GetByName1("Brufen")).Returns(m1);


            return medicineStubRepository.Object;
        }

        private static IOrderRepository GenerateStubDataOrder()
        {
            var orderStubRepository = new Mock<IOrderRepository>();
            return orderStubRepository.Object;
        }
    }
}
