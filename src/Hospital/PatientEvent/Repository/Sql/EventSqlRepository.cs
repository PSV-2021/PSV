﻿using Hospital.PatientEvent.Model;
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
            dbContext.PatientEvents.ToList().ForEach(e => result.Add(new Event(e.Id, e.EventName, e.EventTime, e.EventId)));
            return result;
        }
        
        public Event GetById(int id)
        {
            Event e = dbContext.PatientEvents.FirstOrDefault(ev => ev.Id == id);
            return e;
        }

        public List<Event> GetAllSuccessful()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventName.Equals("1") select n).ToList();
            return result;
        }

        public List<Event> GetAllFirstStep()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventName.Equals("3") select n).ToList();
            return result;
        }

        public List<Event> GetAllThirdStep()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventName.Equals("5") select n).ToList();
            return result;
        }

        public List<Event> GetAllQuit()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventName.Equals("7") select n).ToList();
            return result;
        }

        public List<Event> GetTodaySuccessSchedule()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventTime.Date.Equals(DateTime.Today.Date)
                      && n.EventName.Equals("1") select n).ToList();
            return result;
        }

        public List<Event> GetYesterdaySuccessSchedule()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventTime.Date.Equals(DateTime.Today.AddDays(-1).Date)
                && n.EventName.Equals("1") select n).ToList();
            return result;
        }

        public List<Event> GetTwoDaysAgoSuccessSchedule()
        {
            List<Event> result = new List<Event>();
            result = (from n in dbContext.PatientEvents where n.EventTime.Date.Equals(DateTime.Today.AddDays(-2).Date)
                      && n.EventName.Equals("1") select n).ToList();
            return result;
        }

        public int GetNumberOfDistinctEvents()
        {
            return dbContext.PatientEvents.Select(s => s.EventId).Distinct().Count();
        }
    }
}
