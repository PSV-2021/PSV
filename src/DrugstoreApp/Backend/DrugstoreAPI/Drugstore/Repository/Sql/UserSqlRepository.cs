using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugstore.Repository.Sql
{
    public class UserSqlRepository : IUserRepository
    {
        public MyDbContext DbContext { get; set; }

        public UserSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void Add(User user)
        {
            int id = DbContext.Users.ToList().Count > 0 ? DbContext.Users.ToList().Max(user => user.UserId) + 1 : 1;
            user.UserId = id;
            if (user.Role == "pharmacist") AddPharmacist(user);
            else AddCustomer(user);
        }

        public void AddPharmacist(User user)
        {
            Pharmacist pharmacist = new Pharmacist(user.UserId, user.Username, user.Password, "Farm");
            DbContext.Users.Add(pharmacist);
            DbContext.SaveChanges();
        }
        public void AddCustomer(User user)
        {
            Customer customer = new Customer(user.UserId, user.Username, user.Password, "Cust", "Adresa");
            DbContext.Users.Add(customer);
            DbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            DbContext.Users.ToList().ForEach(user => result.Add(new User(user.UserId, user.Username, user.Password, user.Role)));
            return result;
        }

        public User GetOne(String username)
        {
            User user = DbContext.Users.FirstOrDefault(user => user.Username == username);
            return user;
        }
        public bool CheckUsernameAndPassword(User user)
        {
            User FoundUser = DbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (FoundUser != null)
            {
                return user.Password == FoundUser.Password;
            }
            return false;
        }
    }
}
