using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class Pharmacist : User
    {
        public String Name { get; set; }

        public Pharmacist(){}

        public Pharmacist(int Userid, String username, String password, String name)
        {
            this.UserId = Userid;
            Username = username;
            Password = password;
            Role = "Pharmacist";
            Name = name;
        }
    }
}
