using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class CustomizedUserList
    {
        public List<Product> UserList = new List<Product>();
        public string UserId { get; set; }
        public CustomizedUserList(List<Product> userList, string userId)
        {
            UserList = userList;
            UserId = userId;
        }
    }
}
