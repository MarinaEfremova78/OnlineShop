using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.CurrentUser
{
    public class CurrentUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("CurrentUser", Constants.UserId);
        }
    }
}
