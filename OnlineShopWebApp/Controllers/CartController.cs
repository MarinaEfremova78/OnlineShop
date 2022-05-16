using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        private readonly IProductsStorage productStorage;
        private readonly ICartsStorage cartsStorage;
        public CartController(IProductsStorage productStorage, ICartsStorage cartsStorage, IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
            this.productStorage = productStorage;
            this.cartsStorage = cartsStorage;
        }
        public IActionResult Index()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            if (cart == null || cart.CartElements.Count == 0)
            {
                return RedirectToAction(nameof(IsEmpty));
            }
            return View(cart);
        }

        public IActionResult IsEmpty()
        {
            ViewBag.Message = "В корзине пока нет товаров";
            return View();
        }

        public IActionResult Add(int pageNumber, int productId)
        {
            var product = productStorage.TryGetById(productId);
            cartsStorage.Add(product, Constants.UserId);
            return RedirectToAction(nameof(HomeController.Index), "Home", new { pageNumber });
        }
        public IActionResult Increase(int productId)
        {
            var product = productStorage.TryGetById(productId);
            cartsStorage.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Decrease(int productId)
        {
            cartsStorage.Decrease(productId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            if (cart != null || cart.CartElements.Count != 0)
            {
                cart.Clear();
            }
            return RedirectToAction(nameof(IsEmpty));
        }

    }
}
