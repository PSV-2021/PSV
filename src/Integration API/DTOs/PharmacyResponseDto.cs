using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class PharmacyResponseDto
    {
        
        public string response { get; set; }

        public PharmacyResponseDto(string response)
        {
            
            this.response = response;
        }

        public PharmacyResponseDto()
        {

        }

    }
}
