using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.Pages
{
    public class Pages : ViewComponent
    {
        private readonly IProductsStorage productsStorage;

        public Pages(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IViewComponentResult Invoke(int? pageNumber)
        {
            var pageIndex = (pageNumber ?? 1);
            var products = productsStorage.GetAll();
            var pagesCount = (double)products.Count / 4;
            ViewBag.LastPage = false;
            if (pagesCount <= pageIndex)
            {
                ViewBag.LastPage = true;
            }
            return View("Pages", pageIndex);
        }
    }
}
