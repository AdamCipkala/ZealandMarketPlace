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
    public enum ReviewEnum
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }

    public class ItemDetailsModel : PageModel
    {
        private IItemService _itemService;
        public Item Item { get; set; }
        
        [BindProperty]
        public Review Review { get; set; }

        public ItemDetailsModel(IItemService service)
        {
            _itemService = service;
        }

        public void OnGet(int id)
        {
            Item = _itemService.GetItemDetails(id);
            if (Item == null)
            {
                RedirectToPage("/NotFound");
            }
        }
    }
}