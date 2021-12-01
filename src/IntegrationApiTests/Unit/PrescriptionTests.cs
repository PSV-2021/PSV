using System;
using System.Collections.Generic;
using System.Text;
using Integration_API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace IntegrationApiTests.Unit
{
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

            var result = controler.QrPerscription("");

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

            var result = controler.QrPerscription("");

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

            var result = controler.QrPerscription("");

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
