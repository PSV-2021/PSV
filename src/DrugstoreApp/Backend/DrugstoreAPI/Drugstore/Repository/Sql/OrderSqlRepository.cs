using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Repository.Interfaces;
using System.Linq;

namespace Drugstore.Repository.Sql
{
    public class OrderSqlRepository : IOrderRepository
    {
        public MyDbContext DbContext { get; set; }

        public OrderSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public OrderSqlRepository()
        {
        }

        public List<ShoppingCart> GetAll()
        {
            List<ShoppingCart> result = new List<ShoppingCart>();
            DbContext.Orders.ToList().ForEach(order => result.Add(new ShoppingCart(order.Id, order.ShoppingCartItems, order.TotalPrice, order.OrderType, order.Delivered, order.PickedUp)));

            return result;
        }

        public ShoppingCart GetOne(int id)
        {
            ShoppingCart cart = DbContext.Orders.FirstOrDefault(order => order.Id == id);
            return cart;
        }

        public void Add(ShoppingCart cart)
        {
            int id = DbContext.Orders.ToList().Count > 0 ? DbContext.Orders.ToList().Max(order => order.Id) + 1 : 1;
            cart.Id = id;
            DbContext.Orders.Add(cart);
            DbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            ShoppingCart cart = DbContext.Orders.ToList().Find(order => order.Id == id);
            if (cart == null)
                return false;
            else
            {
                DbContext.Orders.Remove(cart);
                DbContext.SaveChanges();
                return true;
            }
        }
    }
}
