using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class DrugstoreResponse
    {
        public int Id { get; set; }
        public int DrugstoreId { get; set; }
        public string Response { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime RecievedTime { get; set; }

        public DrugstoreResponse()
        {

        }

        public DrugstoreResponse(int Id, int token, string response, DateTime sentTime,
            DateTime recievedTime)
        {
            this.Id = Id;
            DrugstoreId = token;
            Response = response;
            SentTime = sentTime;
            RecievedTime = recievedTime;
        }

    }
}
