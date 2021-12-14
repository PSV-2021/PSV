using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Service
{
    public class OrderService
    {
        public IOrderRepository OrderRepository { get; set; }
        public readonly MyDbContext DbContext;

        public OrderService(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }
        public OrderService(MyDbContext context)
        {
            this.DbContext = context;
            OrderRepository = new OrderSqlRepository(context);
        }
        public List<ShoppingCart> GetAll()
        {
            return OrderRepository.GetAll();
        }
        public ShoppingCart GetOne(int id)
        {
            return OrderRepository.GetOne(id);
        }
        public void Add(ShoppingCart cart)
        {
            OrderRepository.Add(cart);
        }
        public bool Delete(int id)
        {
            return OrderRepository.Delete(id);
        }
       
    }
}
