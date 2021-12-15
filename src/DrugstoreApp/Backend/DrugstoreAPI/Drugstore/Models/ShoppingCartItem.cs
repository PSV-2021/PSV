using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class ShoppingCartItem
    {
        public string MedicineName { get; set; }
        public int Amount { get; set; }

        public ShoppingCartItem(string medicineName, int amount)
        {
            MedicineName = medicineName;
            Amount = amount;
        }

        public ShoppingCartItem() { }
    }
}
