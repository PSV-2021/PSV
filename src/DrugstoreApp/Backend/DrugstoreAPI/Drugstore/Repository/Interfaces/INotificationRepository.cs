using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface INotificationRepository
    {
        public List<Notification> GetAll();
        public Notification GetById(int id);
        public void Add(Notification notification);
        public bool Delete(int id);
        public void Update(Notification notification);
    }
}
