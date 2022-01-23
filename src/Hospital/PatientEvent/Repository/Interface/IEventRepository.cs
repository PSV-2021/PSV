using Hospital.PatientEvent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.PatientEvent.Repository.Interface
{
    public interface IEventRepository
    {
        public List<Event> GetAll();
        public void Save(Event newEvent);
        public Event GetById(int eventId);
    }
}
