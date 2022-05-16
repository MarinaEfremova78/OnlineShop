using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouritesStorage favouritesStorage;

        public FavouriteController(IFavouritesStorage favouritesStorage)
        {
            this.favouritesStorage = favouritesStorage;
        }

        public IActionResult Index()
        {
            var currentUserFavourites = favouritesStorage.TryGetByUserId(Constants.UserId);
            if (currentUserFavourites == null || currentUserFavourites.UserList.Count == 0)
            {
                return RedirectToAction(nameof(IsEmpty));
            }
            return View(currentUserFavourites.UserList);
        }
        public IActionResult IsEmpty()
        {
            ViewBag.Message = "Нет товаров в избранном";
            return View();
        }
        public IActionResult AddToFavourites(int productId, int pageNumber)
        {
            favouritesStorage.Add(productId, Constants.UserId);
            return RedirectToAction(nameof(HomeController.Index), "Home", new { pageNumber });
        }
        public IActionResult Remove(int productId)
        {
            favouritesStorage.Remove(productId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            favouritesStorage.Clear(Constants.UserId);
            return RedirectToAction(nameof(IsEmpty));
        }
    }
}
