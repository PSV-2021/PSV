using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugstore.Models
{
    public class Hospital
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }

        public Hospital(string name, int id, string url, string apiKey)
        {
            this.Name = name;
            this.Id = id;
            this.Url = url;
            this.ApiKey = apiKey;
        }

        public Hospital() { }
    }
}
