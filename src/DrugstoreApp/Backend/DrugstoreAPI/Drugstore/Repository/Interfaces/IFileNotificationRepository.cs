using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface IFileNotificationRepository
    {
        public List<FileNotification> GetAll();
        public FileNotification GetById(int id);
        public void Add(FileNotification notification);
        public bool Delete(int id);
        public void Update(FileNotification notification);
        public void SaveChanges();
    }
}
