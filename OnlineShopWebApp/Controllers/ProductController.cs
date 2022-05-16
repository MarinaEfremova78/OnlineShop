using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productStorage;
        public ProductController(IProductsStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public IActionResult Index(int pageNumber, int id)
        {
            ViewBag.PageNumber = pageNumber;
            var product = productStorage.TryGetById(id);
            if (product == null)
            {
                return RedirectToAction(nameof(HomeController.ProductNotFound), "Home");
            }
            return View(product);
        }
    }
}
