using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class PharmacyResponseDto
    {
        public string Id { get; set; }
        public string Response { get; set; }

        public PharmacyResponseDto(string id,string response)
        {
            this.Id = id;
            this.Response = response;
        }

        public PharmacyResponseDto()
        {

        }

    }
}
