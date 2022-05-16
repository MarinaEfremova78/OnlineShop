using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IComparativesStorage
    {
        List<CustomizedUserList> GetAll();
        CustomizedUserList TryGetByUserId(string userId);
        void Add(int id, string userId);
        void Remove(int id, string userId);
        void Clear(string userId);
    }
}