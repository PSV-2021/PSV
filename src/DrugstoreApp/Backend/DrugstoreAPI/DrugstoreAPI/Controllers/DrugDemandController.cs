using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Service;
using Drugstore.Repository.Interfaces;
using Service;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugDemandController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        public MedicineService medicineService;
        public HospitalService HospitalService;
        public IMedicineRepository MedicineRepository { get; }
        public IHospitalRepository HospitalRepository { get; }
        public DrugDemandController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.HospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
        }

        public DrugDemandController(MedicineSqlRepository medicineRepository, HospitalSqlRepository hospitalRepository) //Radi testiranja
        {
            MedicineRepository = medicineRepository;
            this.medicineService = new MedicineService(MedicineRepository);

            this.HospitalRepository = hospitalRepository;
            this.HospitalService = new HospitalService(HospitalRepository);
        }

        public DrugDemandController(IMedicineRepository medRepo, IHospitalRepository hosRepo)
        {
            MedicineRepository = medRepo;
            this.medicineService = new MedicineService(MedicineRepository);

            HospitalRepository = hosRepo;
            this.HospitalService = new HospitalService(HospitalRepository);
        }

        [HttpPost]
        public IActionResult Post(DrugAmountDemandDto demand)
        {
            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                var headers = Request.Headers["ApiKey"];
                foreach (string header in headers)
                {
                    if (HospitalService.CheckApiKey(header))
                    {
                       return Ok(medicineService.CheckForAmountOfDrug(demand.Name, demand.Amount));
                    }
                }
            }
            return Unauthorized();
        }


    }
}
