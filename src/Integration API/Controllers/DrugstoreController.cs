using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Repository.Sql;
using Integration.Service;
using Integration.Model;
using Model.DataBaseContext;
using Integration_API.DTOs;

using Integration.Service;
using Integration_API.Filters;
using Integration_API.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Integration_API.Repository.Interfaces;
using RestSharp;
using System.Configuration;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public DrugstoreService drugstoreService;
        public IDrugstoreRepository repo = new DrugstoreSqlRepository();



        public DrugstoreController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.drugstoreService = new DrugstoreService(new DrugstoreSqlRepository(dbContext));
        }

        [HttpGet]       // GET /api/drugstore
        public IActionResult Get()
        {
            List<Drugstore> result = new List<Drugstore>();
            drugstoreService.GetAll().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url, drugstore.ApiKey, drugstore.Email,drugstore.Address.Country,drugstore.Address.City, drugstore.Address.Street, drugstore.gRPC)));
            return Ok(result);
        }

        [HttpGet("withimage")]       // GET /api/drugstore
        public IActionResult GetWithImageAndComment()
        {
            List<Drugstore> result = new List<Drugstore>();
            drugstoreService.GetAll().ForEach(drugstore => result.Add(new Drugstore(drugstore.Id, drugstore.Name, drugstore.Url, drugstore.ApiKey, drugstore.Email.EmailValue, drugstore.Address.Country,drugstore.Address.City, drugstore.Address.Street, drugstore.Comment, drugstore.Base64Image, drugstore.gRPC)));
            return Ok(result);
        }

        [HttpGet ("filter")] // GET /api/drugstore/filter

        public IActionResult Filter([FromQuery] string city, [FromQuery] string address)
        {
            IEnumerable<string> headerValues = Request.Headers["ApiKey"];
            var key = headerValues.FirstOrDefault();
            if (key == null || !key.Equals("abcde"))
                return Unauthorized();
            CheckFilterParameters(ref city, ref address);
            List<Drugstore> result = drugstoreService.SearchDrugstoresByCityAndAddress(city, address);
            return Ok(result);
        }


        private static void CheckFilterParameters(ref string city, ref string address)
        {
            if (city == null)
                city = "";
            if (address == null)
                address = "";
        }

        [HttpGet("/name/{id}")] // GET /api/test2/int/3
        public IActionResult GetDrugstoreName(int id)
        {
            string result = drugstoreService.GetDrugstoreName(id);
            return Ok(result);
        }

        [HttpGet("one")] // GET /api/test2/int/3
        public IActionResult GetDrugstoreById([FromQuery] int id)
        {
            Drugstore result = drugstoreService.GetDrugstoreById(id);
            if (result != null)
                return Ok(result);
            
            return BadRequest(false);
        }

        [HttpPost] // POST /api/drugstore/newdrugstore
        public IActionResult Post(RegistrationDto newPharmacy)
        {
            var client = new RestClient(newPharmacy.URLAddress);
            var request = new RestRequest("/api/hospital", Method.POST);

            string ApiKey = Guid.NewGuid().ToString();

            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                HospitalName = "Health",
                URLAddress = "http://localhost:5000",
                ApiKey = ApiKey
            };

            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            request.AddJsonBody(jsonBody);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Drugstore ds = new Drugstore(newPharmacy.DrugstoreName, newPharmacy.URLAddress, ApiKey, newPharmacy.Email, "Srbija",newPharmacy.City,newPharmacy.Address, newPharmacy.gRPC);
                drugstoreService.AddNewDrugstore(ds);
                return Ok(ds);
            }
            return Unauthorized();
        }

        [HttpPut("edit")]
        public IActionResult EditDrugstore(DrugstoreEditDto editDto)
        {
            IEnumerable<string> headerValues = Request.Headers["ApiKey"];
            var key = headerValues.FirstOrDefault();
            if (key == null || !key.Equals("abcde"))
                return Unauthorized(false);

            Drugstore edit = drugstoreService.GetDrugstoreById(editDto.Id);
            if (edit == null)
                return BadRequest(false);
            edit.Base64Image = editDto.ImageBase64;
            edit.Comment = editDto.Comment;

            drugstoreService.Update(edit);

            return Ok(true);
        }
    }
}
