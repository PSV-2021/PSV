using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Service
{
    public class FileNotificationService
    {
        public IFileNotificationRepository NotificationRepository { get; set; }
        public readonly MyDbContext dbContext;
        public FileNotificationService(IFileNotificationRepository notificationRepository)
        {
            NotificationRepository = notificationRepository;
        }

        public FileNotificationService(MyDbContext context)
        {
            this.dbContext = context;
            NotificationRepository = new FileNotificationSqlRepository(context);
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

        public void RefreshNotifications()
        {
            var notifications = dbContext.FileNotifications;
            foreach (FileNotification fn in notifications)
                if (!fn.IsRead)
                    fn.IsRead = true;
            dbContext.SaveChanges();
        }
    }
}
