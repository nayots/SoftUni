using MiniServer.Models;
using System;
using System.Collections.Generic;

namespace MiniServer.Data.Contracts
{
    public interface IOrderRepository : IDisposable
    {
        ICollection<Order> GetAllOrders();

        void AddOrder(Order order);

        Order GetOrderById(int id);

        bool OrderExists(int id);

        void Save();
    }
}