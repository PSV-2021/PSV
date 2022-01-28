using Integration.Models;
using Integration.Notifications.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository.Interfaces
{
    public interface INotificationRepository
    {
        public List<FileNotification> GetAll();
        public FileNotification GetById(int id);
        public void Add(FileNotification notification);
        public bool Delete(int id);
        public void Update(FileNotification notification);
        public void SaveChanges();
    }
}
