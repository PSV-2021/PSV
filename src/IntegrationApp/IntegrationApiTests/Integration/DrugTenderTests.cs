using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Integration.Model;
using Integration.Service;
using Integration.Tendering.Repository.Sql;
using Integration_API.Controllers;
using Integration_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Moq;
using Xunit;

namespace IntegrationApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class DrugTenderTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString());

            context = new MyDbContext(builder.Options);
        }


        [Fact]
        public void GetTenderOffersByTenderId()
        {
            SetUpDbContext();
            var tenderController = new DrugTenderController(context);

            IActionResult result = tenderController.GetAllOffersForTender("2");

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllOngoingTenders()
        {
            SetUpDbContext();
            var tenderController = new DrugTenderController(context);

            IActionResult result = tenderController.GetOnGoing();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CheckDrugstoreProfit()
        {
            SetUpDbContext();
            var tenderService = new DrugTenderService(context);

            double result = tenderService.GetDrugstoreProfit(new DateRange(new DateTime(2021, 11, 30), new DateTime(2022,4,1)), 1);

            Assert.Equal(result, 5500);
        }

        [Fact]
        public void CheckDrugstoreParticipations()
        {
            SetUpDbContext();
            var tenderService = new DrugTenderService(context);

            double result = tenderService.GetDrugstoreParticipations(new DateRange(new DateTime(2021, 11, 30), new DateTime(2022, 4, 1)), 1);

            Assert.Equal(result, 3);
        }

        [Fact]
        public void CheckDrugstoreWins()
        {
            SetUpDbContext();
            var tenderService = new DrugTenderService(context);

            double result = tenderService.GetDrugstoreWins(new DateRange(new DateTime(2021, 11, 30), new DateTime(2022, 4, 1)), 1);

            Assert.Equal(result, 2);
        }

    }
}
