using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class Cart : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;

        public Cart(ICartsStorage cartsStorage)
        {
            this.cartsStorage = cartsStorage;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            var productCount = cart?.Amount ?? 0;
            return View("Cart", productCount);
        }
    }
}
