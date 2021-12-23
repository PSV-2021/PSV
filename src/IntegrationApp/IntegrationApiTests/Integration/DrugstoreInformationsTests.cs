using System;
using System.Collections.Generic;
using System.Text;
using Integration.Repository.Sql;
using Integration.Service;
using Integration_API.Controllers;
using Integration_API.DTOs;
using Integration_API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Xunit;

namespace IntegrationApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class DrugstoreInformationsTests
    {
        private MyDbContext context;
        private void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString());

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Write_new_comment_on_drugstore_test()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";

            var controler = new DrugstoreController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.EditDrugstore(new DrugstoreEditDto(1, "", "Test komentar"));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Try_to_edit_nonexistent_drugstore()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";

            var controler = new DrugstoreController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
            var result = controler.EditDrugstore(new DrugstoreEditDto(0, "nesto", "Test komentar"));

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Wrong_apikey_check()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "something wrong";

            var controler = new DrugstoreController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
            var result = controler.EditDrugstore(new DrugstoreEditDto(0, "nesto", "Test komentar"));

            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void Get_one_drugstore()
        {
            SetUpDbContext();
            var controler = new DrugstoreController(context);
            var result = controler.GetDrugstoreById(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_one_nonexisting_drugstore()
        {
            SetUpDbContext();
            var controler = new DrugstoreController(context);
            var result = controler.GetDrugstoreById(0);

            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
