using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using System.Data.Entity;

namespace ShoppingCartWebAPI.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext()
        {
        }

        public ShoppingDbContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}