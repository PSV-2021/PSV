using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class TenderInfo
    {
        public string DrugName { get; set; }
        public int Amount { get; set; }

        public TenderInfo() { }

        public TenderInfo(string drugName, int drugAmount)
        {
            this.DrugName = drugName;
            this.Amount = drugAmount;
        }
    }
}
