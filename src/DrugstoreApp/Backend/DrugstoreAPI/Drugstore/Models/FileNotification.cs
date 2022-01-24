using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class FileNotification
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public DateTime Posted { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public bool IsRead { get; set; }

        public FileNotification(int id, string hospitalName, DateTime posted, string title, string content, bool isRead)
        {
            Id = id;
            HospitalName = hospitalName;
            Posted = posted;
            Title = title;
            Content = content;
            IsRead = isRead;
        }

        public FileNotification(string hospitalName, DateTime posted, string title, string content, bool isRead)
        {
            HospitalName = hospitalName;
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
