using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_API.Model
{
    public class DrugstoreFeedback
    {
        public int Id { get; set; }
        public string DrugstoreToken { get; set; }
        public string Content { get; set; }
        public string Response { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime RecievedTime { get; set; }

        public DrugstoreFeedback()
        {

        }

        public DrugstoreFeedback(int Id, string token, string content, string response, DateTime sentTime,
            DateTime recievedTime)
        {
            this.Id = Id;
            DrugstoreToken = token;
            Content = content;
            Response = response;
            SentTime = sentTime;
            RecievedTime = recievedTime;
        }
        
    }
}
