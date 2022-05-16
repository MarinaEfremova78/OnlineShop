namespace OnlineShopWebApp
{
    public class CartElement
    {
        public decimal Cost => Product.Cost * Count;
        public Product Product { get; }
        public int Count { get; private set; }

        public CartElement(Product product)
        {
            Product = product;
            Count = 1;
        }

        public void Plus()
        {
            Count++;
        }

        public void Minus()
        {
            Count--;
        }
    }
}
