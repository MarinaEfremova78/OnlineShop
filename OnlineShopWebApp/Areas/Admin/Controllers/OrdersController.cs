using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        public OrdersController(IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
        }
        public IActionResult Index()
        {
            var orders = ordersStorage.GetOrders();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersStorage.TryGetOrderById(orderId);
            return View(order);
        }
        public IActionResult ChangeStatus(Guid orderId, OrderStatuses status)
        {
            var order = ordersStorage.TryGetOrderById(orderId);
            order.Status = status;
            return RedirectToAction(nameof(Index));
        }
    }
}
