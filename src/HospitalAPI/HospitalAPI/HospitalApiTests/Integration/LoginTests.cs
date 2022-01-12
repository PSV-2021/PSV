using Hospital.DTO;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;
using HospitalAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HospitalApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class LoginTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql(Constants.ConnectionString);
            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Login()
        {
            SetUpDbContext();
            context.Add(new Patient(1, "Marko", "Markovic", "3009998805138", new DateTime(1998, 06, 25), Sex.male, "0641664608",
                "Bulevar Oslobodjenja 8", "marko@gmail.com", "miki98", "miki985", true, BloodType.B, "Petar", 1, new List<Allergen>(),""));
            context.Add(new Patient(2, "Milica", "Mikic", "3009998805137", new DateTime(1997, 10, 12), Sex.female, "065245987", "Kisacka 5", "milica@gmail.com",
               "mici97", "mici789", true, BloodType.A, "Nenad", 1, new List<Allergen>(),""));

            UserDTO user = new UserDTO { Username = "mici97", Password = "mici789" };

            LoginController loginController = new LoginController(context);
            IActionResult retVal = loginController.Authentication(user);

            retVal.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Login_manager()
        {
            SetUpDbContext();
            Patient patient1 = new Patient(1, "Marko", "Markovic", "3009998805138", new DateTime(1998, 06, 25), Sex.male, "0641664608",
              "Bulevar Oslobodjenja 8", "marko@gmail.com", "miki98", "miki985", true, BloodType.B, "Petar", 1, new List<Allergen>(), "");
            patient1.Type = UserType.menager;
            context.Add(patient1);
            context.Add(new Patient(2, "Milica", "Mikic", "3009998805137", new DateTime(1997, 10, 12), Sex.female, "065245987", "Kisacka 5", "milica@gmail.com",
               "mici97", "mici789", true, BloodType.A, "Nenad", 1, new List<Allergen>(), ""));

            UserDTO user = new UserDTO { Username = "miki98", Password = "miki985" };

            LoginController loginController = new LoginController(context);
            IActionResult retVal = loginController.Authentication(user);

            retVal.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Authorize_manager_fail()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["role"] = "patient";
           
            var managerCommentsController = new ManagerCommentsController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
            IActionResult retVal = managerCommentsController.Get();

            retVal.Equals(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public void Authorize_manager_success()
        {
            SetUpDbContext();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["role"] = "manager";

            var managerCommentsController = new ManagerCommentsController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
            IActionResult retVal = managerCommentsController.Get();

            retVal.Equals(HttpStatusCode.OK);
        }
    }
}
