using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productStorage;
        public HomeController(IProductsStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(int? pageNumber)
        {
            ViewBag.PageNumber = pageNumber;
            var products = productStorage.GetPageContent(pageNumber);
            return View(products);
        }

        [HttpPost]
        public IActionResult Index(string searchedProduct)
        {
            if (searchedProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var productName = searchedProduct.ToLower();
            var products = productStorage.TryGetByName(productName);
            if (products == null)
            {
                return RedirectToAction(nameof(ProductNotFound));
            }
            ViewBag.SearchKey = searchedProduct;
            return View("SearchResult", products);
        }

        public IActionResult ProductNotFound()
        {
            var pageIndex = 1;
            ViewBag.PageNumber = pageIndex;
            var products = productStorage.GetPageContent(pageIndex);
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
