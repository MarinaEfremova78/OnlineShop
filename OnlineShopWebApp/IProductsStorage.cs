using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsStorage
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        List<Product> TryGetByName(string productName);
        void Remove(int id);
        void Edit(Product product);
        void Create(AdminProductInfo adminProductInfo);
        List<Product> GetPageContent(int? pageNumber);
    }
}
