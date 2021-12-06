
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugstore.Models
{
    public class DrugstoreOffer
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DrugstoreName { get; set; }

        public DrugstoreOffer(string id, string content, string title, DateTime startDate, DateTime endDate, string drugstoreName)
        {
            Id = id;
            Content = content;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            DrugstoreName = drugstoreName;
        }

        public DrugstoreOffer() { }
    }
}
