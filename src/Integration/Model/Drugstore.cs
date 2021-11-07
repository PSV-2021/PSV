using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class Drugstore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Drugstore()
        {

        }
        public Drugstore(int id, string name, string url, string api, string email, string address)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            Email = email;
            Address = address;
        }

        public Drugstore(string name, string url, string api)
        {
            Name = name;
            Url = url;
            ApiKey = api;
        }


    }
}
