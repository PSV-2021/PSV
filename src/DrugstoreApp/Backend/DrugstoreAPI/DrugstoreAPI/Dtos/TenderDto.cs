using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.DTOs
{
    public class TenderDto
    {
        public string Id { get; set; }
        public DateTime TenderEnd { get; set; }
        public List<DrugTenderDto> TenderInfo { get; set; }

        public TenderDto()
        {
            TenderInfo = new List<DrugTenderDto>();
        }

        public TenderDto(string id, DateTime tenderEnd)
        {
            Id = id;
            TenderEnd = tenderEnd;
            TenderInfo = new List<DrugTenderDto>();
        }

        public TenderDto(DateTime tenderEnd, List<DrugTenderDto> tenderInfo)
        {
            TenderEnd = tenderEnd;
            TenderInfo = tenderInfo;
        }
    }
}
