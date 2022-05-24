using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{

    public class ItemDetailsModel : PageModel
    {
        private IItemService _itemService;
        private IOrderService _orderService;
        public Item Item { get; set; }
        public List<string> BoughtContacts { get; set; }

        [BindProperty] public string OwnerId { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        public ItemDetailsModel(IItemService service, IOrderService orderService)
        {
            _orderService = orderService;
            _itemService = service;
        }

        public void OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if (Item == null)
            {
                RedirectToPage("/NotFound");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            BoughtContacts = new List<string>();
            if (string.IsNullOrEmpty(userId)) return;
            var usersOrders = _orderService.GetUserOrders(userId);
            foreach (var order in usersOrders)
            {
                BoughtContacts.Add(order.ContactUser);
            }
        }

        public RedirectResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return new RedirectResult("/Identity/Account/Login");
            }
            var order = new Order
            {
                UserId = userId,
                ContactUser = OwnerId
            };
            _orderService.AddOrder(order);
            return new RedirectResult("/Contacts");

            

        }

        public RedirectResult OnPostReview()
        {
            return new RedirectResult("/Index");
        }
    }
}