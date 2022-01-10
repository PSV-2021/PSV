using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class Deliverer : User
    {
        public String Name { get; set; }
        public List<ShoppingCart> MyOrders { get; set; }
        public Deliverer() { }
        public Deliverer(int Userid, String username, String password, String name)
        {
            UserId = Userid;
            Username = username;
            Password = password;
            Role = "Deliverer";
            this.Name = name;
        }
    }
}
