using Hospital.PatientEvent.Model;
using Hospital.PatientEvent.Repository.Interface;
using Hospital.PatientEvent.Repository.Sql;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.PatientEvent.Service
{
    public class EventService
    {
        public IEventRepository EventRepository { get; set; }
        public readonly MyDbContext dbContext;
        public EventService(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        public EventService(MyDbContext context)
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
