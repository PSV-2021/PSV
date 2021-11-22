using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }

        public User()
        {

        }
        public User(int id, String username, String password, String role)
        {
            UserId = id;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
