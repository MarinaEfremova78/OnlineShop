using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalSum { get { return CartElements ?.Sum(x => x.Cost) ?? 0; } }
        public decimal Amount { get { return CartElements ?.Sum(x => x.Count) ?? 0; } }

        public List<CartElement> CartElements;

        public void Add(Product product)
        {
            var duplicate = CartElements.FirstOrDefault(cartElement => cartElement.Product.Id == product.Id);
            if (duplicate != null)
            {
                duplicate.Plus();
                return;
            }
            CartElements.Add(new CartElement(product));
        }

        public void Decrease(int id)
        {
            var duplicate = CartElements.FirstOrDefault(cartElement => cartElement.Product.Id == id);
            if (duplicate.Count != 1)
            {
                duplicate.Minus();
                return;
            }
            CartElements.Remove(duplicate);
        }
        public void Clear()
        {
            CartElements.Clear();
        }
    }
}
