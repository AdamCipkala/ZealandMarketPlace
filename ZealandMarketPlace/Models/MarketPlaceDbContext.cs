using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZealandMarketPlace.Models
{
    public class MarketPlaceDbContext : DbContext
    {
        public MarketPlaceDbContext()
        {
        }

        public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }        
        public virtual DbSet<Item> Items { get; set; }
    }
}
