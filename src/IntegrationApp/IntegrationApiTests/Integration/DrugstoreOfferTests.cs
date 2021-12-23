using DrugstoreAPI.Controllers;
using Integration.Model;
using Integration.Repository.Sql;
using Integration.Service;
using Integration_API.DTOs;
using Integration_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.DataBaseContext;
using Moq;
using PrimerServis;
using RabbitMQ.Client;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace IntegrationApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class DrugstoreOfferTests
    {
        private MyDbContext context;
        private readonly IServiceScopeFactory scopeFactory;
        PublishedOfferDto exists = new PublishedOfferDto("1");
        PublishedOfferDto Nonexistent = new PublishedOfferDto("2");
        DrugstoreOffer offer1 = new DrugstoreOffer("7", "Content", "title", DateTime.Now, DateTime.Now, "Apotekica", false);

        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString());

            context = new MyDbContext(builder.Options);
        }
        [Fact]
        public void Get_Correct_Number_Of_Offers()
        {
            SetUpDbContext();
            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(context);
            List<DrugstoreOffer> offers = repo.GetAll();
            int val = offers.Count;
            int checkVal = val + 1;
            this.SendDrugOffers();
            int newVal = repo.GetAll().Count;
            newVal.ShouldBe(checkVal);

        }
        private void SendDrugOffers()
        {
            SetUpDbContext();
            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(context);
            var stubRabbitMqService = new Mock<IRabbitMQService>();
            List<DrugstoreOffer> offers = new List<DrugstoreOffer>();
            offer1.SetOfferIdForTesting();
            stubRabbitMqService.Setup(x => x.CreateConnection());
            stubRabbitMqService.Setup(x => x.RecieveMessage()).Returns(offer1);
            repo.Save(offer1);

        }

        [Fact]
        public void Drug_Is_Published()
        {
            SetUpDbContext();
            var Controller = new DrugstoreOfferController(context);
            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(context);
            Controller.Post(exists);
            DrugstoreOffer drugstoreOffer = repo.GetOne(exists.OfferId);
            var result = drugstoreOffer.IsPublished;
            Assert.True(result);
        }

        [Fact]
        public void Published_Drug_doesnt_exist()
        {
            SetUpDbContext();
            var dsController = new DrugstoreOfferController(context);

            var result = dsController.Post(Nonexistent);
            Assert.IsType<UnauthorizedResult>(result);
        }





    }
}
