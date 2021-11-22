
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Dtos
{
    public class DrugstoreOfferDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DrugstoreName { get; set; }

        public DrugstoreOfferDto(string id, string content, string title, DateTime startDate, DateTime endDate, string drugstoreName)
        {
            Id = id;
            Content = content;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            DrugstoreName = drugstoreName;
        }

        public DrugstoreOfferDto() { }
    }
}
