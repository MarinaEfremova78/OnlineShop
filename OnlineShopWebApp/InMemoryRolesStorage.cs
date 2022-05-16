using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryRolesStorage : IRolesStorage
    {
        private List<Role> roles = new List<Role>();
        public List<Role> GetRoles()
        {
            return roles;
        }
        public Role TryGetRoleByName(string roleName)
        {
            return roles.FirstOrDefault(role => role.Name == roleName);
        }
        public void Add(Role role)
        {
            roles.Add(role);
        }
        public void Remove(Role role)
        {
            roles.Remove(role);
        }
    }
}
