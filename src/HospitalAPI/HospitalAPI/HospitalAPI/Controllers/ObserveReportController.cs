using Hospital.DTO;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Hospital.SharedModel;
using HospitalAPI.Authorization;
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
    public class ObserveReportController : ControllerBase
    {
        private MyDbContext context;
        public ObserveAppointmentsService observeAppointmentsService;

        public ObserveReportController(MyDbContext context)
        {
            this.context = context;
            observeAppointmentsService = new ObserveAppointmentsService(new ObserveAppointmentsSqlRepository(context));
        }

        [AuthAttributePatient("Get", "patient")]
        [HttpGet]
        public IActionResult Get([FromQuery] string id)
        {
            int idAppointment = Int32.Parse(id);
            Appointment appointments = observeAppointmentsService.GetById(idAppointment);
            ReportDTO report = ObserveAppointmentsService.ReportDTO(appointments);
            return Ok(report);
        }
    }
}
