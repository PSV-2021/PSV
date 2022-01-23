using Drugstore.Models;
using Drugstore.Service;
using DrugstoreAPI.Adapters;
using DrugstoreAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public EventService eventService;

        public EventController(MyDbContext context)
        {
            this.eventService = new EventService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(eventService.GetAll());
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Event e = eventService.GetOne(id);
            if (e == null) return NotFound();
            else return Ok(EventAdapter.EventToEventDto(e));
        }

        [HttpPost]
        public IActionResult Save(EventDto dto)
        {
            Event e = EventAdapter.EventDtoToEvent(dto);
            eventService.Save(e);
            return Ok();
        }
    }
}
