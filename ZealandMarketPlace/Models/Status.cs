using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZealandMarketPlace.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [DisplayName("Available")]
        public string Available { get; set; }
        [DisplayName("Reserved")]
        public string Reserved { get; set; }
        [DisplayName("SOLD")]
        public string Sold { get; set; }
    }
}
