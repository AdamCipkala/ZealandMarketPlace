using System.Collections.Generic;
using System.Linq;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Services.EFServices
{


    public class EFOrderService : IOrderService
    {
        private MarketPlaceDbContext context;

        public EFOrderService(MarketPlaceDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Order> AllOrders()
        {
            return context.Orders;
        }

        public Order GetOrder(int id)
        {
            return context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            context.Orders.Remove(GetOrder(id));
            context.SaveChanges();
        }

        public IEnumerable<Order> GetUserOrders(string userId)
        {
            return context.Orders.Where(o => o.UserId == userId);
        }

        public IEnumerable<Order> GetReceivedOrders(string userId)
        {
            return context.Orders.Where(o => o.ContactUser == userId);
        }


    }
}