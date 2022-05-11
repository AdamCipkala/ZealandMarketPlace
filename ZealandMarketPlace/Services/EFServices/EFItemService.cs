using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZealandMarketPlace.Services.Interfaces;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.EFServices
{
    public class EFItemService:IItemService
    {
        private MarketPlaceDbContext context;
        public EFItemService(MarketPlaceDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return context.Items;
        }

        public void AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public List<Item> FilterByCategory(Category category)
        {
            return context.Items.Where(item => item.Category.Equals(category)).ToList();
        }

        public List<Item> FilterByPrice(double minPrice, double maxPrice)
        {
            return context.Items.Where(item => item.Price >= minPrice && item.Price <= maxPrice).ToList();
        }

        public List<Item> SearchItem(string name)
        {
            return context.Items.Where(item => item.Name.Contains(name)).ToList();
        }


    }
}
