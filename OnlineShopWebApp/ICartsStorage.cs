using System;

namespace OnlineShopWebApp
{
    public interface ICartsStorage
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Decrease(int productId, string userId);
        void Remove(Guid id);
    }
}
