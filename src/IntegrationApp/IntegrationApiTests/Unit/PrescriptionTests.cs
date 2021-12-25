using System;
using System.Collections.Generic;
using System.Text;
using Integration_API.Controllers;
using Integration_API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace IntegrationApiTests.Unit
{
    [Trait("Type", "UnitTest")]
    public class PrescriptionTests
    {
        [Fact]
        public void Check_if_ApiKey_is_not_valid()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "something wrong";

            var controler = new PrescriptionController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPerscription(new PrescriptionDto(@"http://localhost:5001", "Brufen", 1,
                "Neki opis", "Ime Prezime"));

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void Check_if_URL_is_not_sent()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";

            var controler = new PrescriptionController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPerscription(new PrescriptionDto(null,
                "Brufen", 1, "Neki opis", "Ime Prezime"));

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Check_if_patien_name_is_not_sent()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["ApiKey"] = "abcde";
            httpContext.Request.Headers["Url"] = "someUrl";

            var controler = new PrescriptionController(null)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPerscription(new PrescriptionDto(@"http://localhost:5001", "Brufen", 1, "Neki opis", null));

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
