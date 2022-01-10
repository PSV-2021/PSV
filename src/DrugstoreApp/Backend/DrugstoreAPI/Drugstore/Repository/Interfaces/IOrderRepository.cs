using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public bool Delete(int id);
        public ShoppingCart GetOne(int id);
        public void Add(ShoppingCart cart);
        public List<ShoppingCart> GetAll();
    }
}
