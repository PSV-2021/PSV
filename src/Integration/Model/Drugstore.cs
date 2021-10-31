using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class Drugstore
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Drugstore(string id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
        }

        
    }
}
