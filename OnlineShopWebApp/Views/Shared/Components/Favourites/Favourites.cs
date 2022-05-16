using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.Favourites
{
    public class Favourites : ViewComponent
    {
        private readonly IFavouritesStorage favouritesStorage;
        private readonly IProductsStorage productsStorage;

        public Favourites(IFavouritesStorage favouritesStorage, IProductsStorage productsStorage)
        {
            this.favouritesStorage = favouritesStorage;
            this.productsStorage = productsStorage;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var favourites = favouritesStorage.TryGetByUserId(Constants.UserId);
            if (favourites != null)
            {
                var favouriteProduct = favourites.UserList.FirstOrDefault(product => product.Id == productId);
                ViewBag.Favourite = favouriteProduct;
            }
            var product = productsStorage.TryGetById(productId);
            return View("Favourites", product);
        }
    }
}
