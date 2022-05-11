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
    public class ItemDetailsModel : PageModel
    {
        private IItemService itemService;
        public Item item { get; set; }
        public ItemDetailsModel(IItemService service)
        {
            itemService = service;
        }
        public void OnGet(int itemId)
        {
            item = itemService.GetItemDetails(itemId);
        }
    }
}
