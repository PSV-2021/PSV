using Hospital.PatientEvent.Model;
using Hospital.PatientEvent.Repository.Interface;
using Hospital.PatientEvent.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.PatientEvent.Service
{
    public class EventService
    {
        public IEventRepository EventRepository { get; set; }
        public readonly EventDbContext dbContext;
        public EventService(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        public EventService(EventDbContext context)
        {
            this.dbContext = context;
            EventRepository = new EventSqlRepository(context);
        }

        public List<Event> GetAll()
        {
            return EventRepository.GetAll();
        }

        public Event GetOne(int id)
        {
            return EventRepository.GetById(id);
        }

        public void Save(Event e)
        {
            EventRepository.Save(e);
        }

    }
}
