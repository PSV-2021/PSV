using Integration.IntegrationEvents.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.IntegrationEvents.Repository.Interface
{
    public interface IEventRepository
    {
        public List<Event> GetAll();

        public void Save(Event newEvent);
        public Event GetById(int eventId);
    }
}
