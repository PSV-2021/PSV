using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.IntegrationEvents.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }

        public Event()
        {
        }

        public Event(int id, string eventName, DateTime eventTime)
        {
            Id = id;
            EventName = eventName;
            EventTime = eventTime;
        }
    }
}
