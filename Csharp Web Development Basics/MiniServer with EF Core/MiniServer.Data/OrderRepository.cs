using Microsoft.EntityFrameworkCore;
using MiniServer.Data.Contracts;
using MiniServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniServer.Data
{
    public class OrderRepository : IOrderRepository
    {
        private bool disposed = false;
        private ShopDbContext context;

        public OrderRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public ICollection<Order> GetAllOrders()
        {
            var orders = context.Orders.ToList();

            return orders;
        }

        public Order GetOrderById(int id)
        {
            var order = context.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);

            foreach (var op in order.Products)
            {
                context.Entry(op).Reference(o => o.Product).Load();
            }

            return order;
        }

        public bool OrderExists(int id)
        {
            bool result = context.Orders.Any(o => o.Id == id);

            return result;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}