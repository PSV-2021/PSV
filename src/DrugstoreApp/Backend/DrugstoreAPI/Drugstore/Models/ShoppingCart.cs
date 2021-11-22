using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> ShoppingCartItems;
        public double TotalPrice { get; set; }

        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            TotalPrice = 0;
        }
    }
}
