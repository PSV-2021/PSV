using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class TenderDto
    {
        public DateTime TenderEnd { get; set; }
        public List<DrugTenderDto> TenderInfo { get; set; }

        public TenderDto()
        {
            TenderInfo = new List<DrugTenderDto>();
        }

        public TenderDto(DateTime tenderEnd, List<DrugTenderDto> tenderInfo)
        {
            TenderEnd = tenderEnd;
            TenderInfo = tenderInfo;
        }
    }
}
