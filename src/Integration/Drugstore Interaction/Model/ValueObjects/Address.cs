using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Internal;
using Integration.Shared_Model;
using Microsoft.EntityFrameworkCore;

namespace Integration.Drugstore_Interaction.Model.ValueObjects
{
    [Owned]
    public class Address : ValueObject
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }

        public Address(string country, string city, string street)
        {
            if (country.IsNullOrEmpty() || city.IsNullOrEmpty() || street.IsNullOrEmpty())
                throw new ArgumentException("Some of arguments of address in not set!");
            Country = country;
            City = city;
            Street = street;
        }

        public Address ChangeCountry(string country)
        {
            if (country.IsNullOrEmpty())
                throw new ArgumentException("Country name can not be empty");
            return new Address(country, this.City, this.Street);
        }

        public Address ChangeCity(string city)
        {
            if (city.IsNullOrEmpty())
                throw new ArgumentException("City name can not be empty");
            return new Address(this.Country, city, this.Street);
        }

        public Address ChangeStreet(string street)
        {
            if (street.IsNullOrEmpty())
                throw new ArgumentException("Street name can not be empty");
            return new Address(this.Country, this.City, street);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return Street;
        }
    }
}
