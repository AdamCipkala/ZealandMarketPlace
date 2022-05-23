using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IItemService _itemService;
        public IEnumerable<Item> Items { get; set; }
        public string ImagePath { get; set; }

        public int FavouriteItemId { get; set; }

        public IndexModel(ILogger<IndexModel> logger,IItemService service)
        {
            _logger = logger;
            _itemService = service;
        }

        public void OnGet()
        {
            Items = _itemService.GetAllItems();
        }
        public IActionResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _itemService.AddItemToFavouriteList(FavouriteItemId, userId);
            return RedirectToPage("/Index");
        }
    }
}
