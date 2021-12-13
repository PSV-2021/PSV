using Integration_API.Controllers;
using Integration_API.DTOs;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationApiTests.Integration
{
    public class GrpcDrugDemandAndPurchaseTests
    {
        private MyDbContext context;

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString());

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Drug_demand_when_ok()
        {
            SetUpDbContext();
            DrugAmountDemandDto dto = new DrugAmountDemandDto("http://localhost:5001", "Brufen", 1);
            DrugPurchaseController purchaseController = new DrugPurchaseController(context);
            bool requestOk = purchaseController.drugDemandGrpc(dto);

            Assert.True(requestOk);

        }

        [Fact]
        public void Drug_demand_when_not_ok()
        {
            SetUpDbContext();
            DrugAmountDemandDto dto = new DrugAmountDemandDto("http://localhost:5001", "Ivermektin", 1000);
            DrugPurchaseController purchaseController = new DrugPurchaseController(context);
            bool requestOk = purchaseController.drugDemandGrpc(dto);

            Assert.False(requestOk);

        }

        [Fact]
        public void Drug_purchase()
        {
            SetUpDbContext();
            DrugAmountDemandDto dto = new DrugAmountDemandDto("http://localhost:5001", "Brufen", 1);
            DrugPurchaseController purchaseController = new DrugPurchaseController(context);
            bool requestOk = purchaseController.drugPurchaseGrpc(dto);

            Assert.True(requestOk);
        }

        
    }
}
