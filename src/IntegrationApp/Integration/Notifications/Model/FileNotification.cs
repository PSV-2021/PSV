using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Notifications.Model
{
    public class FileNotification
    {
        public int Id { get; set; }
        public string DrugstoreName { get; set; }
        public DateTime Posted { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public bool IsRead { get; set; }

        public FileNotification(int id, string drugstoreName, DateTime posted, string title, string content, bool isRead)
        {
            Id = id;
            DrugstoreName = drugstoreName;
            Posted = posted;
            Title = title;
            Content = content;
            IsRead = isRead;
        }

        public FileNotification(string drugstoreName, DateTime posted, string title, string content, bool isRead)
        {
            DrugstoreName = drugstoreName;
            Posted = posted;
            Title = title;
            Content = content;
            IsRead = isRead;
        }

        public FileNotification()
        {
        }
    }
}
