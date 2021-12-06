using System;
using System.Collections.Generic;
using System.Text;
using HospitalAPI.Controllers;
using HospitalAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HospitalApiTests.Integration
{
    [Trait("Type", "IntegrationTest")]
    public class PrescriptionTests
    {
        [Fact]
        public void Check_if_drug_doesnt_exists_in_this_drugstore()
        {
            var httpContext = new DefaultHttpContext();
            var controler = new PrescriptionController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPrescription(new PrescriptionDto("http://localhost:5000", "NekiNepostojeci",
                "Nebitno", "Zvonko Zvonkovic"));
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Check_unreachabe_url()
        {
            var httpContext = new DefaultHttpContext();
            var controler = new PrescriptionController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPrescription(new PrescriptionDto("http://localhost:9999", "NekiNepostojeci",
                "Nebitno", "Zvonko Zvonkovic"));
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Check_if_everything_is_ok()
        {
            var httpContext = new DefaultHttpContext();
            var controler = new PrescriptionController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext,
                }
            };

            var result = controler.QrPrescription(new PrescriptionDto("http://localhost:5001", "Brufen",
                "Some description...", "Zvonko Zvonkovic"));
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
