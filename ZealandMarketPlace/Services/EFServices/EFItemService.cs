﻿using System;
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
        public Item GetItem(int itemId)
        {
            return context.Items.FirstOrDefault(i => i.ItemId == itemId);
        }

        public void UpdateItem(Item item)
        {
            context.Update(item);
            context.SaveChanges();
        }

        public void AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Item> FilterByCategory(Category category)
        {
            return context.Items.Where(item => item.Category.Equals(category));
        }

        public IEnumerable<Item> FilterByPrice(double minPrice, double maxPrice)
        {
            return context.Items.Where(item => item.Price >= minPrice && item.Price <= maxPrice);
        }

        public IEnumerable<Item> SearchItem(string name)
        {
            return context.Items.Where(item => item.Name.Contains(name));
        }

        public void DeleteItem(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }

    }
}
