using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{
    public class GetItemsModel : PageModel
    {
        private IItemService itemService;
        public IEnumerable<Item> items { get; set; } 
        public GetItemsModel(IItemService service)
        {
            itemService = service;
        }
        public void OnGet()
        {
            items = itemService.GetAllItems();
        }
    }
}
