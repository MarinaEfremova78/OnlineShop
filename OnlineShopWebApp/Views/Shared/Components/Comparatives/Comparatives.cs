using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.Comparatives
{
    public class Comparatives : ViewComponent
    {
        private readonly IComparativesStorage comparativesStorage;
        private readonly IProductsStorage productsStorage;

        public Comparatives(IComparativesStorage comparativesStorage, IProductsStorage productsStorage)
        {
            this.comparativesStorage = comparativesStorage;
            this.productsStorage = productsStorage;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var comparatives = comparativesStorage.TryGetByUserId(Constants.UserId);
            if (comparatives != null)
            {
                var comparativeProduct = comparatives.UserList.FirstOrDefault(product => product.Id == productId);
                ViewBag.Comparative = comparativeProduct;
            }
            var product = productsStorage.TryGetById(productId);
            return View("Comparatives", product);
        }
    }
}
