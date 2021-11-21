using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Model
{
    public class DrugstoreOffer
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DrugstoreName { get; set; }
        public bool IsPublished { get; set; }

        public DrugstoreOffer(string id, string content, string title, DateTime startDate, DateTime endDate, string drugstoreName, bool isPublished)
        {
            Id = id;
            Content = content;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            DrugstoreName = drugstoreName;
            IsPublished = isPublished;
        }

        public DrugstoreOffer(string id, string content, string title, DateTime startDate, DateTime endDate, string drugstoreName)
        {
            Id = id;
            Content = content;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            DrugstoreName = drugstoreName;
            IsPublished = false;
        }


        public DrugstoreOffer() { }
    }
}
