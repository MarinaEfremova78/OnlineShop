using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IFavouritesStorage
    {
        CustomizedUserList TryGetByUserId(string userId);
        List<CustomizedUserList> GetAll();
        void Add(int id, string userId);
        void Remove(int id, string userId);
        void Clear(string userId);
    }
}