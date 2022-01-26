﻿using Hospital.Schedule.Model;
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
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.Authorization;

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
            appointmentService = new AppointmentService(new RecommendedAppointmentSqlRepository(context), new DoctorSqlRepository(context));
        }

        [AuthAttributePatient("Post", "patient")]
        [HttpPost]
        public IActionResult Post(SearchAppointmentsDTO searchAppointments)
        {
            List<Appointment> appointments = appointmentService.GetAvailableAppointment(searchAppointments).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentService.AvailableAppointmentsDTODoctor(appointments);

            return Ok(dto);
        }

        [AuthAttributePatient("Post", "patient")]
        [HttpPost("schedule")]
        public IActionResult Schedule(ScheduleDTO scheduleDTO)
        {
            Appointment appointment = AppointmentService.ScheduleAppointmentDTOToAppointment(scheduleDTO.Start, scheduleDTO.Id, scheduleDTO.PatientId);
            appointmentService.Schedule(appointment);

            return Ok();
        }

       
    }
}
