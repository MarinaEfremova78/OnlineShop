using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersStorage
    {
        List<User> GetUsers();
        User TryGetUserById(string userId);
        void Add(User user);
        void ChangeUserPassword(UserPasswordInfo passwordInfo);
        void Edit(User user);
        void Remove(string userId);
    }
}
