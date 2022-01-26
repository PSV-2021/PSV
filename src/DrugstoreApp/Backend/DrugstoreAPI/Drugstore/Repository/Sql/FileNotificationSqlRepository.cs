using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Drugstore.Repository.Sql
{
    public class FileNotificationSqlRepository : IFileNotificationRepository
    {
        public MyDbContext DbContext { get; set; }

        public FileNotificationSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public FileNotificationSqlRepository()
        {
        }

        public void Add(FileNotification notification)
        {
            int id = DbContext.FileNotifications.ToList().Count > 0 ? DbContext.FileNotifications.ToList().Max(notification => notification.Id) + 1 : 1;
            notification.Id = id;
            DbContext.FileNotifications.Add(notification);
            DbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            FileNotification notification = DbContext.FileNotifications.ToList().Find(notification => notification.Id == id);
            if (notification == null)
                return false;
            else
            {
                DbContext.FileNotifications.Remove(notification);
                DbContext.SaveChanges();
                return true;
            }
        }

        public List<FileNotification> GetAll()
        {
            List<FileNotification> result = new List<FileNotification>();
            DbContext.FileNotifications.ToList().ForEach(notification => result.Add(new FileNotification(notification.Id, notification.HospitalName, notification.Posted, notification.Title, notification.Content, notification.IsRead)));

            return result;
        }

        public FileNotification GetById(int id)
        {
            return DbContext.FileNotifications.FirstOrDefault(n => n.Id == id);
        }

        public void Update(FileNotification notification)
        {
            DbContext.FileNotifications.Update(notification);
            DbContext.SaveChanges();
        }

        public void Save(FileNotification newObject)
        {
            DbContext.FileNotifications.Add(newObject);
            DbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
