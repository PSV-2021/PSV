using Integration.Models;
using Integration.Notifications.Model;
using Integration.Repository.Interfaces;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
{
    public class NotificationService
    {
        public INotificationRepository NotificationRepository { get; set; }
        public readonly MyDbContext dbContext;
        public NotificationService(INotificationRepository notificationRepository)
        {
            NotificationRepository = notificationRepository;
        }

        public NotificationService(MyDbContext context)
        {
            this.dbContext = context;
            NotificationRepository = new NotificationSqlRepository(context);
        }

        public List<FileNotification> GetAll()
        {
            return NotificationRepository.GetAll();
        }

        public FileNotification GetById(int id)
        {
            return NotificationRepository.GetById(id);
        }

        public void Update(FileNotification notification)
        {
            NotificationRepository.Update(notification);
        }

        public void Add(FileNotification notification)
        {
            NotificationRepository.Add(notification);
        }

        public bool Delete(int id)
        {
            return NotificationRepository.Delete(id);
        }

        public void Save(FileNotification notification)
        {
            dbContext.Notifications.Add(notification);
            dbContext.SaveChanges();
        }

        public void RefreshNotifications()
        {
            var notifications = dbContext.Notifications;
            foreach (FileNotification fn in notifications)
            if (!fn.IsRead)
                    fn.IsRead = true;
            dbContext.SaveChanges();
        }
    }
}
