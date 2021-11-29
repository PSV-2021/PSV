using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
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
    public class SpecialtyController : ControllerBase
    {
        private MyDbContext context;
        public AppointmentService appointmentService;

        public SpecialtyController(MyDbContext context)
        {
            this.context = context;
            appointmentService = new AppointmentService(new AppointmentSqlRepository(context));

        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Appointment> result = new List<Appointment>();
            result = appointmentService.GetAllAppointments();

            return Ok(result);
        }
    }
}
