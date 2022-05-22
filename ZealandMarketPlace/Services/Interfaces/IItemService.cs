using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.Interfaces
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(int itemId);
        void AddItem(Item item);
        IEnumerable<Item> FilterByCategory(Category category);
        IEnumerable<Item> FilterByPrice(double minPrice, double maxPrice);
        IEnumerable<Item> SearchItem(string name);
        
        IEnumerable<Item> GetAllUserItems(string userId);
        void DeleteItem(Item item);
        void UpdateItem(Item item);

        void AddItemToFavouriteList(Item item, string userId);

        public IEnumerable<Item> GetFavouritesList(string userId);
    }
}
