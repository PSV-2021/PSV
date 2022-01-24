using Integration.Models;
using Integration.Notifications.Model;
using Integration.Repository.Interfaces;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Repository.Sql
{
    public class NotificationSqlRepository : INotificationRepository
    {
        public MyDbContext DbContext { get; set; }

        public NotificationSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public NotificationSqlRepository()
        {
        }

        public void Add(FileNotification notification)
        {
            int id = DbContext.Notifications.ToList().Count > 0 ? DbContext.Notifications.ToList().Max(notification => notification.Id) + 1 : 1;
            notification.Id = id;
            DbContext.Notifications.Add(notification);
            DbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            FileNotification notification = DbContext.Notifications.ToList().Find(notification => notification.Id == id);
            if (notification == null)
                return false;
            else
            {
                DbContext.Notifications.Remove(notification);
                DbContext.SaveChanges();
                return true;
            }
        }

        public List<FileNotification> GetAll()
        {
            List<FileNotification> result = new List<FileNotification>();
            DbContext.Notifications.ToList().ForEach(notification => result.Add(new FileNotification(notification.Id, notification.DrugstoreName, notification.Posted, notification.Title, notification.Content, notification.IsRead)));

            return result;
        }

        public FileNotification GetById(int id)
        {
            return DbContext.Notifications.FirstOrDefault(n => n.Id == id);
        }

        public void Update(FileNotification notification)
        {
            DbContext.Notifications.Update(notification);
            DbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
