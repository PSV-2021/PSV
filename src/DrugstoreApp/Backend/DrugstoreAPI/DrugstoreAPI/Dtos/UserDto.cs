using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
    }
}
