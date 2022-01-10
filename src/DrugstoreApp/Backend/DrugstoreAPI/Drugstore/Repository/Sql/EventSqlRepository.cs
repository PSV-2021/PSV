using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugstore.Repository.Sql
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
            int id = dbContext.DrugstoreEvents.ToList().Count > 0 ? dbContext.DrugstoreEvents.ToList().Max(medicine => medicine.Id) + 1 : 1;
            newEvent.Id = id;
            dbContext.DrugstoreEvents.Add(newEvent);
            dbContext.SaveChanges();
        }

        public List<Event> GetAll()
        {
            List<Event> result = new List<Event>();
            dbContext.DrugstoreEvents.ToList().ForEach(e => result.Add(new Event(e.Id, e.EventName, e.EventTime)));
            return result;
        }

        public Event GetById(int id)
        {
            Event e = dbContext.DrugstoreEvents.FirstOrDefault(ev => ev.Id == id);
            return e;
        }
    }
}
