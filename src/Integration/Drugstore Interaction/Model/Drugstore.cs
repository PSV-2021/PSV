﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration.Model
{
    public class Drugstore
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public string Base64Image { get; set; }

        public Drugstore()
        {

        }
        public Drugstore( string name, string url, string api, string email,string city, string address)
        {
            Name = name;
            Url = url;
            ApiKey = api;
            Email = email;
            City = city;
            Address = address;
        }
        public Drugstore(int id,string name, string url, string api, string email, string city,string address)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            Email = email;
            City = city;
            Address = address;
        }

        public Drugstore(int id, string name, string url, string api, string email, string city, string address, string comment, string image)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            Email = email;
            City = city;
            Address = address;
            Comment = comment;
            Base64Image = image;
        }

        public Drugstore(string name, string url, string api)
        {
            Name = name;
            Url = url;
            ApiKey = api;
        }

    }
}
