﻿using Hospital.Schedule.Repository;
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
    public class CancelAppointmentsController : ControllerBase
    {
        private MyDbContext context;
        public ObserveAppointmentsService observeAppointmentsService;

        public CancelAppointmentsController(MyDbContext context)
        {
            this.context = context;
            observeAppointmentsService = new ObserveAppointmentsService(new ObserveAppointmentsSqlRepository(context));
        }

        [HttpPost]
        public IActionResult CancelAppointment(int appointmentId)
        {
            observeAppointmentsService.CancelAppointment(appointmentId);
            return Ok();
        }
    }
}
