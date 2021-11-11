using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Models
{
    public class FeedbackResponseDto
    {
        public string Response { get; set; }
        public string Id { get; set; }
        public string HospitalName { get; set; }


        public FeedbackResponseDto(string id, string response, string hospitalName)
        {
            this.Id = id;
            this.Response = response;
            this.HospitalName = hospitalName;

        }

        public FeedbackResponseDto()
        {
        }
    }
}