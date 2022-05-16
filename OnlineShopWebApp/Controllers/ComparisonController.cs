using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IComparativesStorage comparativesStorage;

        public ComparisonController(IComparativesStorage comparativesStorage)
        {
            this.comparativesStorage = comparativesStorage;
        }
        public IActionResult Index()
        {
            var currentUserComparatives = comparativesStorage.TryGetByUserId(Constants.UserId);
            if(currentUserComparatives == null || currentUserComparatives.UserList.Count == 0)
            {
               return RedirectToAction(nameof(IsEmpty));
            }
            return View(currentUserComparatives.UserList);
        }
        public IActionResult IsEmpty()
        {
            ViewBag.Message = "Нет товаров для сравнения";
            return View();
        }

        public IActionResult AddToComparison(int productId, int pageNumber)
        {
            comparativesStorage.Add(productId, Constants.UserId);
            return RedirectToAction(nameof(HomeController.Index), "Home", new { pageNumber });
        }
        public IActionResult Remove(int productId)
        {
            comparativesStorage.Remove(productId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            comparativesStorage.Clear(Constants.UserId);
            return RedirectToAction(nameof(IsEmpty));
        }
    }
}
