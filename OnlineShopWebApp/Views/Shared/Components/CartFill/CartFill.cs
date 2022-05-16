using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.CartFill
{
    public class CartFill : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;
        private readonly IProductsStorage productsStorage;

        public CartFill(ICartsStorage cartsStorage, IProductsStorage productsStorage)
        {
            this.cartsStorage = cartsStorage;
            this.productsStorage = productsStorage;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            if (cart != null)
            {
                var cartFill = cart.CartElements.FirstOrDefault(element => element.Product.Id == productId);
                ViewBag.CartElement = cartFill;
            }
            var product = productsStorage.TryGetById(productId);
            return View("CartFill", product);
        }
    }
}
