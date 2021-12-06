using System;
using System.Collections.Generic;
using System.Text;
using Integration.Model;
using Integration.Repository.Sql;
using Integration.Service;
using Integration_API.Controllers;
using Integration_API.DTOs;
using Integration_API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Moq;
using RestSharp;
using Shouldly;
using Xunit;

namespace IntegrationApiTests.Integration
{
    [Trait("Type","IntegrationTest")]
    public class DrugSpecificationTests
    {
        private MyDbContext context;
        
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Drug_spec_when_exists()
        {
            SetUpDbContext();
            var dsController = new DrugSpecificationController(context);

            var result = dsController.Put(new DrugSpecificationRequestDTO("http://localhost:5001", "brufen"));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Drug_spec_when_doesnt_exist()
        {
            SetUpDbContext();
            var dsController = new DrugSpecificationController(context);

            var result = dsController.Put(new DrugSpecificationRequestDTO("http://localhost:5001", "febricet"));
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Drug_spec_when_server_is_down()
        {
            SetUpDbContext();
            var dsController = new DrugSpecificationController(context);

            var result = dsController.Put(new DrugSpecificationRequestDTO("http://localhost:8080", "prospan"));
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
