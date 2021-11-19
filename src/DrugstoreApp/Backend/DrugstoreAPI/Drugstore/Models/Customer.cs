using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class Customer : User
    {
        public String Name { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Customer(int id, String username, String password, String name)
        {
            UserId = id;
            Username = username;
            Password = password;
            Role = "Customer";
            Name = name;
        }
    }
}
