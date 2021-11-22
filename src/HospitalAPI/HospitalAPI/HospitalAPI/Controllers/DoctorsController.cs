﻿using Hospital.Model;
using Hospital.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext context;
        public DoctorService doctorService;

        public DoctorsController(MyDbContext context)
        {
            this.context = context;
            doctorService = new DoctorService(new DoctorSqlRepository(context));
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Doctor> result = new List<Doctor>();
            result = doctorService.GetGeneralDoctors();
            return Ok(result);
        }
    }
}
