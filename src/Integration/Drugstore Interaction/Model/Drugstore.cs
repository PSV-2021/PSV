using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Integration.Drugstore_Interaction.Model.ValueObjects;

namespace Integration.Model
{
    public class Drugstore
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public Email Email { get; set; }
        public Address Address { get; set;}
        public string Comment { get; set; }
        public string Base64Image { get; set; }

        public bool gRPC { get; set; }

        public Drugstore()
        {

        }
        public Drugstore( string name, string url, string api, string email,string country, string city, string street, bool grpc)
        {
            Name = name;
            Url = url;
            ApiKey = api;
            Email = new Email(email);
            Address = new Address(country, city, street);
            gRPC = grpc;
        }
        public Drugstore(int id,string name, string url, string api, Email email, string country,string city,string street, bool grpc)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            Email = email;
            Address = new Address(country, city, street);
            gRPC = grpc;
        }

        public Drugstore(int id, string name, string url, string api, bool grpc)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            gRPC = grpc;
        }

        public Drugstore(int id, string name, string url, string api, string email, string country,string city, string street, string comment, string image, bool grpc)
        {
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            Email = new Email(email);
            Address = new Address(country, city, street);
            Comment = comment;
            Base64Image = image;
            gRPC = grpc;
        }

        public Drugstore(string name, string url, string api)
        {
            Name = name;
            Url = url;
            ApiKey = api;
        }

    }
}
