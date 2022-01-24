using Hospital.PatientEvent.Dto;
using Hospital.PatientEvent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Adapters
{
    public class EventAdapter
    {
        public static Event EventDtoToEvent(EventDto dto)
        {
            Event e = new Event();
            e.Id = dto.Id;
            e.EventName = dto.EventName;
            e.EventTime = DateTime.Now;
            return e;
        }

        public static EventDto EventToEventDto(Event e)
        {
            EventDto dto = new EventDto();
            dto.Id = e.Id;
            dto.EventTime = e.EventTime.ToString();
            dto.EventName = e.EventName;
            return dto;
        }
    }
}
