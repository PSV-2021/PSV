using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Integration.IntegrationEvents.Model
{
    [Table("IntegrationEvents", Schema = "IntegrationEvent")]
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
