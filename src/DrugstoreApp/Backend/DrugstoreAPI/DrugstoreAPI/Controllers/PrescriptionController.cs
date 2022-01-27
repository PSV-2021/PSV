using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Drugstore.Models;
using RestSharp;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public PrescriptionController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("qr")]
        public IActionResult QrPerscription([FromBody] string file)
        {
            var key = Request.Headers["ApiKey"].FirstOrDefault();
            if (key == null || !key.Equals("DrugStoreSecretKey"))
                return Unauthorized();

            var name = Request.Headers["Patient"].FirstOrDefault();
            if (name == null)
                return BadRequest();

            try
            {
                SavePdf(file, name);
            }
            catch
            {
                return BadRequest();
            }

            return Ok("Perscription created!");
        }

        private static void SavePdf(string file, string name)
        {
            byte[] bytes = Convert.FromBase64String(file);
            FileStream stream =
                new FileStream(
                    @"Prescriptions/" + DateTime.Now.ToString("dd.MM.yyyy") + name + new Random().Next(100) +
                    ".pdf", FileMode.CreateNew);
            BinaryWriter writer =
                new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
        }
    }
}
