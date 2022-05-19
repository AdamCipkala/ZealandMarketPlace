using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Areas.Identity.Pages.Account.Manage
{
    public class ManageItems : PageModel
    {
        private IItemService _itemService;
        public IEnumerable<Item> Items { get; set; }
       
        public ManageItems(IItemService service)
        {
            _itemService = service;
        }
        
        public void OnGet()
        {
            Items = _itemService.GetAllItems();
        }
    }
}