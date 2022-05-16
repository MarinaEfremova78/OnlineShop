using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsStorage productStorage;
        public ProductsController(IProductsStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index()
        {
            var products = productStorage.GetAll();
            return View(products);
        }
        public IActionResult Details(int productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }
        public IActionResult Remove(int productId)
        {
            productStorage.Remove(productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productStorage.Edit(product);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminProductInfo adminProductInfo)
        {
            if (ModelState.IsValid)
            {
                productStorage.Create(adminProductInfo);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
    }
}
