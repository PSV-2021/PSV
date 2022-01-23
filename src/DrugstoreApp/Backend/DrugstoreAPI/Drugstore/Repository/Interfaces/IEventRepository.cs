using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface IEventRepository
    {
        public List<Event> GetAll();
        
        public void Save(Event newEvent);
        public Event GetById(int eventId);
    }
}
