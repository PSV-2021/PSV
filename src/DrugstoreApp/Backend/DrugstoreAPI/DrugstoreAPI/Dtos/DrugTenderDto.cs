using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.DTOs
{
    public class DrugTenderDto
    {
        public string DrugName { get; set; }
        public int Amount { get; set; }

        public DrugTenderDto() { }

        public DrugTenderDto(string drugName, int drugAmount)
        {
            this.DrugName = drugName;
            this.Amount = drugAmount;
        }
    }
}
