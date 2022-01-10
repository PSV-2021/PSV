using Integration.IntegrationEvents.Model;
using Integration.IntegrationEvents.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.IntegrationEvents.Repository.Sql
{
    public class EventSqlRepository : IEventRepository
    {
        public EventDbContext dbContext { get; set; }

        public EventSqlRepository(EventDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EventSqlRepository()
        {

        }

        public void Save(Event newEvent)
        {
            int id = dbContext.IntegrationEvents.ToList().Count > 0 ? dbContext.IntegrationEvents.ToList().Max(medicine => medicine.Id) + 1 : 1;
            newEvent.Id = id;
            dbContext.IntegrationEvents.Add(newEvent);
            dbContext.SaveChanges();
        }

        public List<Event> GetAll()
        {
            List<Event> result = new List<Event>();
            dbContext.IntegrationEvents.ToList().ForEach(e => result.Add(new Event(e.Id, e.EventName, e.EventTime)));
            return result;
        }

        public Event GetById(int id)
        {
            Event e = dbContext.IntegrationEvents.FirstOrDefault(ev => ev.Id == id);
            return e;
        }
    }
}
