using System;
using System.Collections.Generic;
using System.Text;
using Integration.Drugs.Service;
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
    [Trait("Type", "IntegrationTest")]

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

            var result = dsController.Put(new DrugSpecificationRequestDTO("http://localhost:5001", "Brufen"));
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

        [Theory]
        [MemberData(nameof(FileNames))]
        public void Download_drug_specification_file(string fileName, bool expectedOutcome)
        {
            DrugSpecificationService service = new DrugSpecificationService();

            bool isDownloaded = service.DownloadDrugSpecification(fileName);

            Assert.Equal(expectedOutcome, isDownloaded);
        }

        public static IEnumerable<object[]> FileNames()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Brufen - Specifikacija leka.pdf", true });
            retVal.Add(new object[] { "Palitreks - Specifikacija leka.pdf", true });

            return retVal;
        }
    }
}
