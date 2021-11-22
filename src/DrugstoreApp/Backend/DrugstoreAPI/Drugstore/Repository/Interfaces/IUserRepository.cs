using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface IUserRepository
    {
        public void Add(User user);
        public List<User> GetAll();
        public User GetOne(String username);
        public bool CheckUsernameAndPassword(User user);
    }
}
