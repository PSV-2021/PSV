using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class TenderFinisherDTO
    {
        public string drugstoreName { get; set; }
        public string tenderId { get; set; }

        public TenderFinisherDTO() { }

        public TenderFinisherDTO(string drugstoreId, string tenderId)
        {
            this.drugstoreName = drugstoreName;
            this.tenderId = tenderId;
        }
    }
}
