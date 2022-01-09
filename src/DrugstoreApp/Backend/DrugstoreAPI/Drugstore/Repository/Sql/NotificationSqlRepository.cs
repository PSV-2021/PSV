using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugstore.Repository.Sql
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

        public void Add(Notification notification)
        {
            int id = DbContext.Notifications.ToList().Count > 0 ? DbContext.Notifications.ToList().Max(notification => notification.Id) + 1 : 1;
            notification.Id = id;
            DbContext.Notifications.Add(notification);
            DbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            Notification notification = DbContext.Notifications.ToList().Find(notification => notification.Id == id);
            if (notification == null)
                return false;
            else
            {
                DbContext.Notifications.Remove(notification);
                DbContext.SaveChanges();
                return true;
            }
        }

        public List<Notification> GetAll()
        {
            List<Notification> result = new List<Notification>();
            DbContext.Notifications.ToList().ForEach(notification => result.Add(new Notification(notification.Id, notification.Posted, notification.Title, notification.Content, notification.Recipients)));

            return result;
        }

        public Notification GetById(int id)
        {
            return DbContext.Notifications.FirstOrDefault(n => n.Id == id);
        }

        public void Update(Notification notification)
        {
            DbContext.Notifications.Update(notification);
            DbContext.SaveChanges();
        }
    }
}
