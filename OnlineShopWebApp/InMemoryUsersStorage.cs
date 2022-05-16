using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryUsersStorage : IUsersStorage
    {
        private List<User> users = new List<User>();

        public List<User> GetUsers()
        {
            return users;
        }
        public User TryGetUserById(string userId)
        {
            return users.FirstOrDefault(user => user.Id == userId);
        }
        public void Add(User user)
        {
            users.Add(user);
        }
        public void ChangeUserPassword(UserPasswordInfo passwordInfo)
        {
            var user = TryGetUserById(passwordInfo.UserId);
            if (user != null)
            {
                user.Password = passwordInfo.Password;
                user.ConfirmPassword = passwordInfo.ConfirmPassword;
            }
        }
        public void Edit(User changedUser)
        {
            var user = TryGetUserById(changedUser.Id);
            if (user != null)
            {
                if(changedUser.PhoneNumber == null)
                {
                    changedUser.PhoneNumber = "-";
                }
                user.Id = changedUser.EmailAddress;
                user.Name = changedUser.Name;
                user.Surname = changedUser.Surname;
                user.EmailAddress = changedUser.EmailAddress;
                user.PhoneNumber = changedUser.PhoneNumber;
            }
        }
        public void Remove(string userId)
        {
            var user = TryGetUserById(userId);
            if(user != null)
            {
                users.Remove(user);
            }
        }
    }
}
