using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{
    public class AddItemModel : PageModel
    {
        private IItemService itemService;
        
        [BindProperty]
        public Item Item { get; set; }

        public AddItemModel(IItemService iService)
        {
            itemService = iService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        
        [HttpPost]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            foreach(var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Item.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            Item.Status = Status.Available;
            Item.DateTime = DateTime.Now;
            Item.Category = Category.Clothes;
            itemService.AddItem(Item);
            return RedirectToPage("../Index");
        }
    }
}
