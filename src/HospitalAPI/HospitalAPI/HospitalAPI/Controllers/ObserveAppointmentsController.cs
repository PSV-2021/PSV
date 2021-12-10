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
    public class ObserveAppointmentsController : ControllerBase
    {
        private MyDbContext context;
        public ObserveAppointmentsService observeAppointmentsService;

        public ObserveAppointmentsController(MyDbContext context)
        {
            this.context = context;
            observeAppointmentsService = new ObserveAppointmentsService(new ObserveAppointmentsSqlRepository(context));
        }
        [HttpGet]
        public IActionResult Get([FromQuery]string id)
        {
            int idPatient = Int32.Parse(id);
            List<Appointment> appointments = observeAppointmentsService.GetAppointmentsById(idPatient);
            return Ok(appointments);
        }
    }
}
