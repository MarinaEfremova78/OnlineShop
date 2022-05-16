using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersStorage : IOrdersStorage
    {
        private List<Order> orders = new List<Order>();

        public List<Order> GetOrders()
        {
            return orders;
        }
        public void Add(Order order)
        {
            orders.Add(order);
        }

        public Order TryGetOrderById(Guid id)
        {
            return orders.FirstOrDefault(order => order.Id == id);
        }
    }
}
