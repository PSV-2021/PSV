using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Model;
using Integration_API.DTOs;
using Model.DataBaseContext;
using Integration.Drugs.DTOs;
using Integration.Drugs.Service;
using System.IO;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugSpecificationController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private DrugSpecificationService drugSpecificationService;

        public DrugSpecificationController(MyDbContext db)
        {
            this.dbContext = db;
            this.drugSpecificationService = new DrugSpecificationService();
        }

        private string FormatDrugsSpecificationsPath()
        {
            return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "DrugsSpecifications" + Path.DirectorySeparatorChar;
        }

        [HttpGet]
        [Route("pdf/{fileName?}")]
        public IActionResult GetSpec(string fileName)
        {
            if (fileName == null)
                return BadRequest();
            var localFile = FormatDrugsSpecificationsPath() + fileName;
            Stream stream = System.IO.File.OpenRead(localFile);

            var binaryFile = ReadFile(stream);
            return File(binaryFile, "application/pdf");
        }

        private static byte[] ReadFile(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(drugSpecificationService.GetFiles());
        }

        [HttpGet("files")]
        public IActionResult GetRefreshedFiles([FromQuery] string filename)
        {
            if (drugSpecificationService.DownloadDrugSpecification(filename))
                return Ok(true);
            return Ok(false);
        }

        [HttpPut]
        public IActionResult Put(DrugSpecificationRequestDTO specRequest)
        {
            var client = new RestClient(specRequest.PharmacyUrl);
            var request = new RestRequest("/api/drugSpecification", Method.POST);

            SetApiKeyInHeader(specRequest, request);
            SetRequestBody(specRequest, request);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(true);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return NoContent();
            return Unauthorized(false);
        }

        private static void SetRequestBody(DrugSpecificationRequestDTO specRequest, RestRequest request)
        {
            var body = new
            {
                Name = specRequest.Name,
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);
        }

        private void SetApiKeyInHeader(DrugSpecificationRequestDTO specRequest, RestRequest request)
        {
            string ApiKey = "";
            foreach (var df in dbContext.Drugstores.ToList())
            {
                if (df.Url.Equals(specRequest.PharmacyUrl))
                {
                    ApiKey = df.ApiKey;
                    break;
                }
            }

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", ApiKey);
        }
    }
}
