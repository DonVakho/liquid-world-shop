using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LiquidWorld.Data.Models;
namespace LiquidWorld.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext")
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public System.Data.Entity.DbSet<LiquidWorld.Data.Models.Order> Orders { get; set; }
    }
}
