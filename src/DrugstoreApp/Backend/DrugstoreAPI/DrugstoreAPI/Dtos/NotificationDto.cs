using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.DTOs
{
    public class NotificationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        public List<String> Recipients { get; set; }
        

        public NotificationDto() { }

        public NotificationDto(string title, string content, DateTime posted, List<string> recipients)
        {
            Title = title;
            Content = content;
            Posted = posted;
            Recipients = recipients;
        }
    }
}
