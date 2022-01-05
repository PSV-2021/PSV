using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
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

            IActionResult result = tenderController.GetAllOffersForTender(2);

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



    }
}
