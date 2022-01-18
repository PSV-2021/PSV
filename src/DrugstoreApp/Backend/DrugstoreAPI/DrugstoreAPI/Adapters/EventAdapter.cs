using Drugstore.Models;
using DrugstoreAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Adapters
{
    public class EventAdapter
    {
        public static Event EventDtoToEvent(EventDto dto)
        {
            Event e = new Event();
            e.Id = dto.Id;
            e.EventName = dto.EventName;
            e.EventTime = dto.EventTime;
            return e;
        }

        public static EventDto EventToEventDto(Event e)
        {
            EventDto dto = new EventDto();
            dto.Id = e.Id;
            dto.EventTime = e.EventTime;
            dto.EventName = e.EventName;
            return dto;
        }
    }
}
