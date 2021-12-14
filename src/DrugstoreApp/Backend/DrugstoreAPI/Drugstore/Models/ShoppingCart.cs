using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems;
        public double TotalPrice { get; set; }
        public OrderType OrderType { get; set; }
        public bool Delivered { get; set; }
        public bool PickedUp { get; set; }

        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            TotalPrice = 0;
        }

        public ShoppingCart(int id, List<ShoppingCartItem> shoppingCartItems, double totalPrice, OrderType orderType, bool delivered, bool pickedUp)
        {
            Id = id;
            ShoppingCartItems = shoppingCartItems;
            TotalPrice = totalPrice;
            OrderType = orderType;
            Delivered = delivered;
            PickedUp = pickedUp;
        }
    }
}
