using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Hospital.SharedModel;
using HospitalAPI.DTO;
using HospitalAPI.Verification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardAppointmentController : ControllerBase
    {
        private readonly MyDbContext context;
        public AppointmentService appointmentService;
        public AppointmentVerification appointmentVerification = new AppointmentVerification();

        public StandardAppointmentController(MyDbContext context)
        {
            this.context = context;
            appointmentService = new AppointmentService(new AppointmentSqlRepository(context));
        }
        [HttpPost]
        public IActionResult Post(Appointment appointment)
        {
            return Ok(appointmentService.SaveAppointment(appointment));
        }

        [HttpGet("{idDoctor}/{chosenDate}")]
        public IActionResult GetFreeAppointments(string idDoctor, string chosenDate)
        {
            Console.WriteLine(chosenDate);
            Console.WriteLine(idDoctor);
            List<Appointment> result = new List<Appointment>();
            int id = int.Parse(idDoctor);
            DateTime date = DateTime.ParseExact(chosenDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            //DateTime date = DateTime.Parse(chosenDate);
            result = appointmentService.GetAppointmentsByDoctorAndDate(id, date);
            return Ok(result);
        }
        [HttpPost("schedule")]
        public IActionResult Schedule([FromBody] AppointmentDTO appointment)
        {
            if (!appointmentVerification.Verify(appointment))
                return BadRequest();
            Appointment appointmentToSchedule = GenerateAppointmentFromDTO(appointment);
            appointmentService.SaveAppointmentSql(appointmentToSchedule, context);
            return Ok();
        }


        private static Appointment GenerateAppointmentFromDTO(AppointmentDTO p)
        {
            Appointment appointment = new Appointment(DateTime.ParseExact(p.StartTime, "dd/MM/yyyy hh:mm:ss", null), 30, "", false, 
                Int32.Parse(p.DoctorId), Int32.Parse(p.PatientId), false);
            

            return appointment;
        }

    }
}

