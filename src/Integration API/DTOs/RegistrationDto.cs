using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class RegistrationDto
    { 
        public string DrugstoreName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string URLAddress { get; set; }

        public RegistrationDto(string name, string address, string email, string url)
        {
            this.DrugstoreName = name;
            this.Address = address;
            this.Email = email;
            this.URLAddress = url;
        }

        public RegistrationDto()
        {

        }

    }
}
