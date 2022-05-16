using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersStorage usersStorage;

        public UsersController(IUsersStorage usersStorage)
        {
            this.usersStorage = usersStorage;
        }

        public IActionResult Index()
        {
            var users = usersStorage.GetUsers();
            return View(users);
        }
        public IActionResult Details(string userId)
        {
            var user = usersStorage.TryGetUserById(userId);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ChangePassword(string userId)
        {
            var user = usersStorage.TryGetUserById(userId);
            if (user != null)
            {
                var userInfoForPaswordChange = new UserPasswordInfo
                {
                    UserId = user.Id,
                };
                return View(userInfoForPaswordChange);
            }
            return RedirectToAction(nameof(Details));
        }

        [HttpPost]
        public IActionResult ChangePassword(UserPasswordInfo passwordInfo)
        {
            if (passwordInfo.UserId == passwordInfo.Password)
            {
                ModelState.AddModelError("", "Пароль не может совпадать с Email");
            }
            var user = usersStorage.TryGetUserById(passwordInfo.UserId);
            if (user != null)
            {
                if (passwordInfo.Password == user.Password)
                {
                    ModelState.AddModelError("", "Новый пароль совпадает с предыдущим");
                    return View(passwordInfo);
                }
            }
            if (ModelState.IsValid)
            {
                usersStorage.ChangeUserPassword(passwordInfo);
                ViewBag.PasswordIsChanged = true;
                return View("PasswordIsChanged", user);
            }
            ViewBag.PasswordIsChanged = false;
            return View("PasswordIsChanged", user);
        }
        public IActionResult Edit(string userId)
        {
            var user = usersStorage.TryGetUserById(userId);
            if (user != null)
            {               
                return View(user);
            }
            return RedirectToAction(nameof(Details));
        }

        [HttpPost]
        public IActionResult Edit(User changedUser)
        {
                usersStorage.Edit(changedUser);
                return RedirectToAction(nameof(Details), new { userId = changedUser.Id });
        }
        public IActionResult Remove(string userId)
        {
            usersStorage.Remove(userId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
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
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
