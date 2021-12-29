using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class TenderOfferDto
    {
        public string DrugstoreName { get; set; }
        public List<DrugTenderDto> TenderInfo { get; set; }
        public int Price { get; set; }

        public TenderOfferDto()
        {
            TenderInfo = new List<DrugTenderDto>();
        }

        public TenderOfferDto(string drugstoreName ,List<DrugTenderDto> tenderInfo, int price)
        {
            DrugstoreName = drugstoreName;
            TenderInfo = tenderInfo;
            Price = price;
        }
    }
}
