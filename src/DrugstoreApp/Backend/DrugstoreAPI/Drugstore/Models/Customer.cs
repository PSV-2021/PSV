using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Drugstore.Models
{
    public class Customer : User
    {
        public String Name { get; set; }
        public String Adress { get; set; }
        [NotMapped]
        public ShoppingCart ShoppingCart { get; set; }
        public Customer() { }
        public Customer(int id, String username, String password, String name, String adress)
        {
            UserId = id;
            Username = username;
            Password = password;
            Role = "Customer";
            Name = name;
            Adress = adress;
        }
    }
}
