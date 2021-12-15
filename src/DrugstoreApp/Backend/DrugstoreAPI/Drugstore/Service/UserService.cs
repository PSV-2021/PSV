using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Service
{
    public class UserService
    {
        public IUserRepository UserRepository { get; set; }
        public readonly MyDbContext dbContext;
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public UserService(MyDbContext context)
        {
            this.dbContext = context;
            UserRepository = new UserSqlRepository(context);
        }

        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }
        public User GetOne(String username)
        {
            return UserRepository.GetOne(username);
        }

        public void Add(User user)
        {
            UserRepository.Add(user);
        }

        public bool Login(User user)
        {
            return CheckUsernameAndPassword(user);
        }

        public bool CheckUsernameAndPassword(User user)
        {
            return UserRepository.CheckUsernameAndPassword(user);
        }

    }
}
