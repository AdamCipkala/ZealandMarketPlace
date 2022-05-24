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
        public IEnumerable<Item> filteredItems { get; set; }
        [BindProperty] public string SearchName { get; set; }
        [BindProperty] public int MinPrice { get; set; }
        [BindProperty] public int MaxPrice { get; set; }
        public Item Item { get; set; }
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

        public IActionResult OnPostNameSearch()
        {
            filteredItems = _itemService.SearchItem(SearchName);
            Items = filteredItems;
            return Page();
        }

        public IActionResult OnPostCategoryFilter(Category category)
        {
            filteredItems = _itemService.FilterByCategory(category);
            Items = filteredItems;
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            filteredItems = _itemService.FilterByPrice(MinPrice,MaxPrice);
            Items = filteredItems;
            return Page();
        }
    }
}
