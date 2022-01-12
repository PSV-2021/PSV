using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Service
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

        public List<Notification> GetAll()
        {
            return NotificationRepository.GetAll();
        }

        public Notification GetById(int id)
        {
            return NotificationRepository.GetById(id);
        }

        public void Add(Notification notification)
        {
            NotificationRepository.Add(notification);
        }

        public bool Delete(int id)
        {
            return NotificationRepository.Delete(id);
        }


        public List<Notification> GetUserNotification(string username)
        {
            List<Notification> allNotifications = GetAll();
            List<Notification> userNotifications = new List<Notification>();

            foreach (Notification notification in allNotifications)
            {
                foreach (String recipient in notification.Recipients)
                {
                    if (recipient.Equals(username))
                        userNotifications.Add(notification);
                }
            }
            return userNotifications;
        }
    }
}
