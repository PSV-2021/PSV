using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Hospital.SharedModel;
using HospitalAPI.DTO;
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
    public class RecommendedAppointmentController : ControllerBase
    {
        private readonly MyDbContext context;
        public AppointmentService appointmentService;

        public RecommendedAppointmentController(MyDbContext context)
        {
            this.context = context;
            //repoSurvey = new SurveySqlRepository(db);
            appointmentService = new AppointmentService();
        }


        [HttpPost("availablePriority")]
        public IActionResult GetAvailable(SearchAppointmentsDTO searchAppointments)
        {
            //List<Appointment> appointments = appointmentService.GetAvailableByStrategy(searchAppointments.Priority).ToList();
            
            return Ok();
        }
    }
}
