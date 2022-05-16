using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryComparativesStorage : IComparativesStorage
    {
        private readonly IProductsStorage productsStorage;
        private List<CustomizedUserList> allUsersComparatives = new List<CustomizedUserList>();

        public InMemoryComparativesStorage(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public List<CustomizedUserList> GetAll()
        {
            return allUsersComparatives;
        }
        public CustomizedUserList TryGetByUserId(string userId)
        {
            return allUsersComparatives.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(int id, string userId)
        {
            var addedProduct = productsStorage.TryGetById(id);
            if (addedProduct != null)
            {
                var existingList = allUsersComparatives.FirstOrDefault(list => list.UserId == userId);
                if (existingList != null)
                {
                    var product = existingList.UserList.FirstOrDefault(x => x.Id == id);
                    if (product == null)
                    {
                        existingList.UserList.Add(addedProduct);
                    }
                }
                else
                {
                    existingList = new CustomizedUserList(new List<Product>(), userId);
                    existingList.UserList.Add(addedProduct);
                    allUsersComparatives.Add(existingList);
                }
            }
        }

        public void Remove(int id, string userId)
        {
            var existingList = allUsersComparatives.FirstOrDefault(list => list.UserId == userId);
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
            if (allUsersComparatives.Count != 0)
            {
                var existingList = allUsersComparatives.FirstOrDefault(list => list.UserId == userId);
                if (existingList != null)
                {
                    existingList.UserList.Clear();
                }
            }
        }
    }
}
