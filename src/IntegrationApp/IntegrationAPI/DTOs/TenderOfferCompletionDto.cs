using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class TenderOfferCompletionDto
    {
        public string Id { get; set; }
        public DateTime TenderEnd { get; set; }
        public List<DrugTenderDto> TenderInfo { get; set; }
        public bool IsWinner { get; set; }


        public TenderOfferCompletionDto()
        {
            TenderInfo = new List<DrugTenderDto>();
        }

        public TenderOfferCompletionDto(string id, DateTime tenderEnd, List<DrugTenderDto> tenderInfo, bool isWinner)
        {
            Id = id;
            TenderEnd = tenderEnd;
            TenderInfo = tenderInfo;
            this.IsWinner = isWinner;
        }
        public TenderOfferCompletionDto(string id, DateTime tenderEnd, bool isWinner)
        {
            Id = id;
            TenderEnd = tenderEnd;
            TenderInfo = new List<DrugTenderDto>();
            this.IsWinner = isWinner;
        }
    }
}
