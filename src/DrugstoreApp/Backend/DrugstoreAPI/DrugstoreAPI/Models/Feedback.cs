using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Models
{
    public class Feedback
    {
        public string HospitalName { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
        public string Response { get; set; }

        public Feedback(string hospitalName, int id, string content, string response)
        {
            this.HospitalName = hospitalName;
            this.Id = id;
            this.Content = content;
            this.Response = response;
        }

        public Feedback() { }
    }
}
