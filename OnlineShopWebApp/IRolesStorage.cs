using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRolesStorage
    {
        List<Role> GetRoles();
        Role TryGetRoleByName(string roleName);
        void Add(Role role);
        void Remove(Role role);
    }
}
