using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Posted { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public List<String> Recipients { get; set; }

        public Notification() { }

        public Notification(int id, DateTime posted, string title, string content,List<String> recipients)
        {
            Id = id;
            Posted = posted;
            Title = title;
            Content = content;
            Recipients = recipients;
        }

        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Notification))
            {
                return false;
            }
            return (this.Id == ((Notification)obj).Id)
                && (this.Posted == ((Notification)obj).Posted)
                && (this.Title == ((Notification)obj).Title)
                && (this.Content == ((Notification)obj).Content);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Posted.GetHashCode() ^ Title.GetHashCode() ^ Content.GetHashCode();
        }
    }
}
