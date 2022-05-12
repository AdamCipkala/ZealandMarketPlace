using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZealandMarketPlace.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Clothes")]
        public string Clothes { get; set; }
        [DisplayName("Shoes")]
        public string Shoes { get; set; }
        [DisplayName("Books")]
        public string Books { get; set; }

    }
}
