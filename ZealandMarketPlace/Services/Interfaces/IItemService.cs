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

        void DeleteItem(Item item);
    }
}
