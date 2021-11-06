using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class DrugstoreFeedback
    {
        public string Id { get; set; }
        public int DrugstoreId { get; set; }
        public string Content { get; set; }
        public string Response { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime RecievedTime { get; set; }

        public DrugstoreFeedback()
        {

        }
        public DrugstoreFeedback(string Id, int token, string content, string response, DateTime sentTime,
            DateTime recievedTime)
        {
            this.Id = Id;
            DrugstoreId = token;
            Content = content;
            Response = response;
            SentTime = sentTime;
            RecievedTime = recievedTime;
        }

        public DrugstoreFeedback(int token, string content, string response, DateTime sentTime,
            DateTime recievedTime)
        {
            DrugstoreId = token;
            Content = content;
            Response = response;
            SentTime = sentTime;
            RecievedTime = recievedTime;
        }

    }
}
