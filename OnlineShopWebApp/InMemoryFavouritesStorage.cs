using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryFavouritesStorage : IFavouritesStorage
    {
        private readonly IProductsStorage productsStorage;
        public List<CustomizedUserList> allUsersFavourites = new List<CustomizedUserList>();

        public InMemoryFavouritesStorage(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public List<CustomizedUserList> GetAll()
        {
            return allUsersFavourites;
        }
        public CustomizedUserList TryGetByUserId(string userId)
        {
            return allUsersFavourites.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(int id, string userId)
        {
            var addedProduct = productsStorage.TryGetById(id);
            if (addedProduct != null)
            {
                var existingFavourites = allUsersFavourites.FirstOrDefault(x => x.UserId == userId);
                if (existingFavourites != null)
                {
                    var product = existingFavourites.UserList.FirstOrDefault(x => x.Id == id);
                    if (product == null)
                    {
                        existingFavourites.UserList.Add(addedProduct);
                    }
                }
                else
                {
                    existingFavourites = new CustomizedUserList(new List<Product>(), userId);
                    existingFavourites.UserList.Add(addedProduct);
                    allUsersFavourites.Add(existingFavourites);
                }
            }
        }
        public void Remove(int id, string userId)
        {
            var existingList = allUsersFavourites.FirstOrDefault(list => list.UserId == userId);
            if (existingList != null)
            {
                var product = existingList.UserList.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    existingList.UserList.Remove(product);
                }
            }
        }
        public void Clear(string userId)
        {
            if (allUsersFavourites.Count != 0)
            {
                var existingList = allUsersFavourites.FirstOrDefault(list => list.UserId == userId);
                if (existingList != null)
                {
                    existingList.UserList.Clear();
                }
            }
        }
    }
}
