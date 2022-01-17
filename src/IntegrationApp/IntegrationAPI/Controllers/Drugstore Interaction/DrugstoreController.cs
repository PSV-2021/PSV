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
            try
            {
                List<Drugstore> result = new List<Drugstore>();
                drugstoreService.GetAll().ForEach(drugstore => result.Add(drugstore));
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }

        [HttpGet("withimage")]       // GET /api/drugstore
        public IActionResult GetWithImageAndComment()
        {
            try
            {
                List<Drugstore> result = new List<Drugstore>();
                drugstoreService.GetAll().ForEach(drugstore => result.Add(drugstore));
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
            
        }

        [HttpGet ("filter")] // GET /api/drugstore/filter

        public IActionResult Filter([FromQuery] string city, [FromQuery] string address)
        {
            try
            {
                IEnumerable<string> headerValues = Request.Headers["ApiKey"];
                var key = headerValues.FirstOrDefault();
                if (key == null || !key.Equals("abcde"))
                    return Unauthorized("You are not authorized for this action.");
                CheckFilterParameters(ref city, ref address);
                List<Drugstore> result = drugstoreService.SearchDrugstoresByCityAndAddress(city, address);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
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
            try
            {
                string result = drugstoreService.GetDrugstoreName(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }

        [HttpGet("one")] // GET /api/test2/int/3
        public IActionResult GetDrugstoreById([FromQuery] int id)
        {
            try
            {
                Drugstore result = drugstoreService.GetDrugstoreById(id);
                if (result != null)
                    return Ok(result);

                return BadRequest("This drugstore doesn't exit!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
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
            return Unauthorized("You are not authorized for this action.");
        }

        [HttpPut("edit")]
        public IActionResult EditDrugstore(DrugstoreEditDto editDto)
        {
            try
            {
                IEnumerable<string> headerValues = Request.Headers["ApiKey"];
                var key = headerValues.FirstOrDefault();
                if (key == null || !key.Equals("abcde"))
                    return Unauthorized("You are not authorized for this action.");

                Drugstore edit = drugstoreService.GetDrugstoreById(editDto.Id);
                if (edit == null)
                    return BadRequest("This drugstore doesn't exist!");

                UpdateDrugstoreInfo(editDto, edit);

                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "This service is not available at the moment" });
            }
        }

        private void UpdateDrugstoreInfo(DrugstoreEditDto editDto, Drugstore edit)
        {
            if (editDto.ImageBase64 != null)
                edit.ChangeDrugstoreLogo(editDto.ImageBase64);
            if (editDto.Comment != null)
                edit.ChangeDrugstoreComment(editDto.Comment);
            drugstoreService.Update(edit);
        }
    }
}
