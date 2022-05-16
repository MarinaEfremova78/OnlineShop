using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryCartsStorage : ICartsStorage
    {
        private List<Cart> carts = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(Product product, string userId)
        {
            var cart = TryGetByUserId(userId);
            if (cart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CartElements = new List<CartElement>()
                    {
                        new CartElement(product)
                    }
                };

                carts.Add(newCart);
            }
            else
            {
                cart.Add(product);
            }
        }

        public void Decrease(int productId, string userId)
        {
            var cart = TryGetByUserId(userId);
            if (cart != null)
            {
                cart.Decrease(productId);
            }
        }

        public void Remove(Guid id)
        {
            var cart = carts.FirstOrDefault(cart => cart.Id == id);
            carts.Remove(cart);
        }
    }
}
