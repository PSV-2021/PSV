using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class DrugAmountDemandDto
    {
        public string PharmacyUrl { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        DrugAmountDemandDto() { }

        DrugAmountDemandDto(string pharmacyUrl, string drugName, int drugAmount)
        {
            this.PharmacyUrl = pharmacyUrl;
            this.Name = drugName;
            this.Amount = drugAmount;
        }
    }
}
