using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class TenderIdDTO
    {
        public string id { get; set; }

        public TenderIdDTO(string id)
        {

            this.id = id;
        }

        public TenderIdDTO()
        {

        }

    }
}
