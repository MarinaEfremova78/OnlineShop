using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IRolesStorage rolesStorage;

        public RolesController(IRolesStorage rolesStorage)
        {
            this.rolesStorage = rolesStorage;
        }

        public IActionResult Index()
        {
            var roles = rolesStorage.GetRoles();
            return View(roles);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesStorage.TryGetRoleByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesStorage.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
        public IActionResult Remove(string roleName)
        {
            var role = rolesStorage.TryGetRoleByName(roleName);
            if (role != null)
            {
                rolesStorage.Remove(role);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
