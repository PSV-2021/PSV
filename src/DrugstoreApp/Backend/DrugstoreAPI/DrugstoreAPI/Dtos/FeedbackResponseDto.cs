using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Models
{
    public class FeedbackResponseDto
    {
        public int Id { get; set; }
        public string Response { get; set; }

        public FeedbackResponseDto(int id, string response)
        {
            this.Id = id;
            this.Response = response;
        }

        public FeedbackResponseDto() { }
    }
}
