using Hospital.PatientEvent.Model;
using Hospital.PatientEvent.Repository.Interface;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.PatientEvent.Repository.Sql
{
    public class EventSqlRepository : IEventRepository
    {
        public MyDbContext dbContext { get; set; }

        public EventSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EventSqlRepository()
        {

        }

        public void Save(Event newEvent)
        {
            int id = dbContext.PatientEvents.ToList().Count > 0 ? dbContext.PatientEvents.ToList().Max(medicine => medicine.Id) + 1 : 1;
            newEvent.Id = id;
            dbContext.PatientEvents.Add(newEvent);
            dbContext.SaveChanges();
        }

        public List<Event> GetAll()
        {
            List<Event> result = new List<Event>();
            dbContext.PatientEvents.ToList().ForEach(e => result.Add(new Event(e.Id, e.EventName, e.EventTime)));
            return result;
        }

        public Event GetById(int id)
        {
            Event e = dbContext.PatientEvents.FirstOrDefault(ev => ev.Id == id);
            return e;
        }

    }
}
