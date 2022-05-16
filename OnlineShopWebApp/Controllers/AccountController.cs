using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersStorage usersStorage;

        public AccountController(IUsersStorage usersStorage)
        {
            this.usersStorage = usersStorage;
        }

        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signin(UserSignInInfo userSignIn)
        {
            var currentUser = usersStorage.TryGetUserById(userSignIn.EmailAddress);
            if (currentUser == null)
            {
                return View("UnknownUserSignIn");
            }
            if(currentUser.Password != userSignIn.Password)
            {
                ModelState.AddModelError("", "Неверный пароль");
                return View(userSignIn);
            }
            if (ModelState.IsValid)
            {                             
                Constants.UserId = currentUser.Id;
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.EmailAddress == user.Password)
            {
                ModelState.AddModelError("", "Пароль не может совпадать с Email");
            }
            if (ModelState.IsValid)
            {
                var newUser = usersStorage.TryGetUserById(user.EmailAddress);
                if (newUser == null)
                {
                    user.Id = user.EmailAddress;
                    if (user.PhoneNumber == null)
                    {
                        user.PhoneNumber = "-";
                    }
                    usersStorage.Add(user);
                }
                Constants.UserId = user.EmailAddress;
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(user);
        }
    }

}
