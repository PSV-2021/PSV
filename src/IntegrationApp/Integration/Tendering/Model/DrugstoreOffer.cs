using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Newtonsoft.Json;

namespace Integration.Model
{
    public class DrugstoreOffer
    {   [Key]
        [JsonProperty]
        public string Id { get; private set; }
        [JsonProperty]
        public string Content { get; private set; }
        [JsonProperty]
        public string Title { get; private set; }
        //public DateTime StartDate { get; private set; }
        //public DateTime EndDate { get; private set; }
        [JsonProperty]
        public DateRange TimeRange { get; private set; }
        [JsonProperty]
        public string DrugstoreName { get; private set; }
        [JsonProperty]
        public bool IsPublished { get; private set; }

        public DrugstoreOffer(string id, string content, string title, DateTime startDate, DateTime endDate, string drugstoreName, bool isPublished)
        {
            ValidateOffer(content, title, drugstoreName);
            Id = id;
            Content = content;
            Title = title;
            TimeRange = new DateRange(startDate, endDate);
            DrugstoreName = drugstoreName;
            IsPublished = isPublished;
        }

        public DrugstoreOffer(string id, string content, string title, string drugstoreName, bool isPublished)
        {
            ValidateOffer(content, title, drugstoreName);
            Id = id;
            Content = content;
            Title = title;
            DrugstoreName = drugstoreName;
            IsPublished = isPublished;
        }

        public DrugstoreOffer(string id, string content, string title, DateTime startDate, DateTime endDate, string drugstoreName)
        {
            ValidateOffer(content, title, drugstoreName);
            Id = id;
            Content = content;
            Title = title;
            TimeRange = new DateRange(startDate, endDate);
            DrugstoreName = drugstoreName;
            IsPublished = false;
        }


        public DrugstoreOffer() { }

        public void PublishOffer()
        {
            IsPublished = true;
        }

        public void UnpublishOffer()
        {
            IsPublished = false;
        }

        public void SetOfferIdForTesting()
        {
            Id = Guid.NewGuid().ToString();
        } 

        private static void ValidateOffer(string content, string title, string drugstoreName)
        {
            if (content.IsNullOrEmpty()) throw new ArgumentException("Offer content must be defined");
            if (title.IsNullOrEmpty()) throw new ArgumentException("Offer title must be defined");
            if (drugstoreName.IsNullOrEmpty()) throw new ArgumentException("Offer drugtore name must be defined");
        }
    }
}
