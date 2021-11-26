using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration.Model
{
    public class DrugConsumed
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public DateTime DateConsumed { get; set; }

        public DrugConsumed(string drugName, int amount, DateTime dateConsumed)
        {
            Name = drugName;
            Amount = amount;
            DateConsumed = dateConsumed;
        }

        public DrugConsumed(int id, string drugName, int amount, DateTime dateConsumed)
        {
            Id = id;  
            Name = drugName;
            Amount = amount;
            DateConsumed = dateConsumed;
        }

        public DrugConsumed() {}

        private string FormatDate()
        {
            return DateConsumed.Day.ToString() + "-" + DateConsumed.Month.ToString() + "-" + DateConsumed.Year.ToString();
        }
    }
}
