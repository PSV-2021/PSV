using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_API.Model
{
    public class Drugstore
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }

        public Drugstore()
        {

        }
        public Drugstore(string id, string name, string url, string api)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
        }

        
    }
}
