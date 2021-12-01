using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Controllers;
using DrugstoreAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DrugstoreApiTests.Integration
{
    
    public class DrugstoreOfferTests
    {
   
        public DrugstoreOfferDto drugstoreOfferDto = new DrugstoreOfferDto("12","brufen na akciji","Akcija", DateTime.Now, DateTime.Now, "Apoteka");

        private MyDbContext context;
        private void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Check_If_Message_Got_Saved()
        {
            SetUpDbContext();
            var controller = new DrugstoreOfferController(context);
            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(context);
            List<DrugstoreOffer> offers = repo.GetAll();
            int val = offers.Count;
            controller.Post(drugstoreOfferDto);
            int newVal = repo.GetAll().Count;
            newVal.ShouldBe(++val);
        }
    }
}
