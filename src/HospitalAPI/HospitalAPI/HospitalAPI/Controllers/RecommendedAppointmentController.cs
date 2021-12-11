using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Hospital.SharedModel;
using Hospital.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Schedule.Repository;
using System.Globalization;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendedAppointmentController : ControllerBase
    {
        private readonly MyDbContext context;
        public AppointmentService appointmentService;
        public MedicalRecordService medicalRecordService;

        public RecommendedAppointmentController(MyDbContext context)
        {
            this.context = context;
            appointmentService = new AppointmentService(new RecommendedAppointmentSqlRepository(context));
        }


        [HttpPost]
        public IActionResult Post(SearchAppointmentsDTO searchAppointments)
        {
            List<Appointment> appointments = appointmentService.GetAvailableAppointment(searchAppointments).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentService.AvailableAppointmentsDTODoctor(appointments);

            return Ok(dto);
        }

        [HttpPost("schedule")]
        public IActionResult Schedule(DateTime start, int doctorId)
        {
            Appointment appointment = AppointmentService.ScheduleAppointmentDTOToAppointment(start, doctorId);
            bool scheduledAppointment = appointmentService.Schedule(appointment);

            if (scheduledAppointment == false)
                return BadRequest("Can not schedule appointment");

            return Ok("Scheduled!");
        }
    }
}
