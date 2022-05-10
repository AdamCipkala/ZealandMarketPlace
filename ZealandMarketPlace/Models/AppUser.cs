using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZealandMarketPlace.Models
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
