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
        private IItemService _itemService;
        public IEnumerable<Item> Items { get; set; }
        public string ImagePath { get; set; }
       
        public GetItemsModel(IItemService service)
        {
            _itemService = service;
        }
        
        public void OnGet()
        {
            Items = _itemService.GetAllItems();
        }
    }
}
