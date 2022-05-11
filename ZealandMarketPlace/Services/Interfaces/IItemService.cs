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
        void AddItem(Item item);
        List<Item> FilterByCategory(Category category);
        List<Item> FilterByPrice(double minPrice, double maxPrice);
        List<Item> SearchItem(string name);
    }
}
