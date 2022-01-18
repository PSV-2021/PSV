using Integration.IntegrationEvents.Model;
using Integration.IntegrationEvents.Repository.Interface;
using Integration.IntegrationEvents.Repository.Sql;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.IntegrationEvents.Service
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
