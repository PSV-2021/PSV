using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Integration.Drugstore_Interaction.Model.ValueObjects;
using Integration.Service;

namespace Integration.Model
{
    public class Drugstore
    {
        [Key]
        public int Id { get; private set;}
        public string Name { get; private set; }
        public string Url { get; private set; }
        public string ApiKey { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public string Comment { get; private set; }
        public string Base64Image { get; private set; }
        public bool gRPC { get; private set;}

        public Drugstore() { }
        public Drugstore( string name, string url, string api, string email,string country, string city, string street, bool grpc)
        {
            CheckIsDataValid(name, url, api);
            Name = name;
            Url = url;
            ApiKey = api;
            Email = new Email(email);
            Address = new Address(country, city, street);
            gRPC = grpc;
        }

        public Drugstore(int id,string name, string url, string api, Email email, string country,string city,string street, bool grpc)
        {
            CheckIsDataValid(name, url, api);
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
            CheckIsDataValid(name, url, api);
            Id = id;
            Name = name;
            Url = url;
            ApiKey = api;
            gRPC = grpc;
        }

        public void ChangeDrugstoreLogo(string base64Image)
        {
            if (base64Image.Length >= 116 || base64Image.Length < 1) {
                this.Base64Image = base64Image;
                return;
            }

            throw new ArgumentException("Invalid logo sent!");
        }

        public void ChangeDrugstoreComment(string comment)
        {
            if(comment.Length > 4048)
                throw new ArgumentException("Comment to long!");
            Comment = comment;
        }

        public bool IsApiKeyEqual(string key)
        {
            if (ApiKey.Equals(key))
                return true;
            return false;
        }

        public bool ContainsAddress(string city, string street)
        {
            if (Address.City.Contains(city) && Address.Street.Contains(street))
                return true;
            return false;
        }

        private static void CheckIsDataValid(string name, string url, string api)
        {
            if (name == null || name.Equals(""))
                throw new ArgumentException("Drugstore name can not be empty");
            if (url == null || url.Equals(""))
                throw new ArgumentException("Drugstore url can not be empty");
            if (api == null || api.Equals(""))
                throw new ArgumentException("Drugstore api address can not be empty");
        }

    }
}
