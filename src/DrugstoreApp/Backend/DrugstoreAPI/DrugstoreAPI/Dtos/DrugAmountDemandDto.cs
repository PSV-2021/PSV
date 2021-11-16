using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Dtos
{
    public class DrugAmountDemandDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public DrugAmountDemandDto() { }

        public DrugAmountDemandDto(string drugName, int drugAmount)
        {
            this.Name = drugName;
            this.Amount = drugAmount;
        }
    }
}
