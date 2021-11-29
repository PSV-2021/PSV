using Hospital.Schedule.Model;
using Hospital.SharedModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardAppointmentController : ControllerBase
    {
        private readonly MyDbContext context;
        public StandardAppointmentController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult Post(Appointment appointment)
        {
            return Ok();
        }
    }
}
