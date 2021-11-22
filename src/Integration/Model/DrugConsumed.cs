using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class DrugConsumed
    {
        public String Name { get; set; }
        public int Amount { get; set; }
        public DateTime DateConsumed { get; set; }

        public DrugConsumed(string drugName, int amount, DateTime dateConsumed)
        {
            Name = drugName;
            Amount = amount;
            DateConsumed = dateConsumed;
        }

        public DrugConsumed() {}
    }
}
