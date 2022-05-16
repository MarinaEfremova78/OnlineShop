using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        private readonly ICartsStorage cartsStorage;

        public OrderController(IOrdersStorage ordersStorage, ICartsStorage cartsStorage)
        {
            this.ordersStorage = ordersStorage;
            this.cartsStorage = cartsStorage;
        }
        public IActionResult Index(Guid id)
        {
            var order = ordersStorage.TryGetOrderById(id);
            return View(order);
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(UserDeliveryInfo user)
        {
            if (ModelState.IsValid)
            {
                if (Constants.UserId == "Unknown_user")
                {
                    return View("UnknownUserOrder");
                }
                if (user.Comment == null)
                {
                    user.Comment = "Нет комментариев";
                }
                var cart = cartsStorage.TryGetByUserId(Constants.UserId);
                var order = new Order
                {
                    User = user,
                    Cart = cart,
                    CustomerId = Constants.UserId,
                    Status = OrderStatuses.Created
                };
                ordersStorage.Add(order);
                cartsStorage.Remove(cart.Id);
                return RedirectToAction("Index", new { id = order.Id });
            }
            return RedirectToAction(nameof(CheckOut));
        }
    }
}
