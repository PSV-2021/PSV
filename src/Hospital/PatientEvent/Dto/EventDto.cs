using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.PatientEvent.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventTime { get; set; }

        public EventDto()
        {
        }

        public EventDto(int id, string eventName, string eventTime)
        {
            Id = id;
            EventName = eventName;
            EventTime = eventTime;
        }
    }
}
