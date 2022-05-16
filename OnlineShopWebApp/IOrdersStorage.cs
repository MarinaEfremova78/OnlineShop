using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersStorage
    {
        void Add(Order order);
        Order TryGetOrderById(Guid id);
        List<Order> GetOrders();
    }
}
