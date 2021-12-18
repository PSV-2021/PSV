using System;

namespace Hospital.MedicalRecords.Model
{
    public class UserFeedback
    {
        public int Id { get; set; }
        public DateTime TimeWritten { get; set; }
        public String Content { get; set; }
        public String Name { get; set; }
        public Boolean canPublish { get; set; }

        public UserFeedback() { }

        public UserFeedback(int id, DateTime po, int r, string con)
        {
            Id = id;
            TimeWritten = po;
            //Rating = r;
            Content = con;
            //IsDeleted = false;
        }
        public UserFeedback(int id, DateTime date, string context, string name, Boolean canPublish)
        {
            Id = id;
            TimeWritten = date;
            Name = name;
            Content = context;
            canPublish = true;
        }

        public UserFeedback(DateTime time, string content, string name, bool v)
        {
            TimeWritten = time;
            Content = content;
            Name = name;
            canPublish = v;
        }
    }
}

