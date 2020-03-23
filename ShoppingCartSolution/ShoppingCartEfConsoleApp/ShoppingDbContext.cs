using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ShoppingCartLibrary;

namespace ShoppingCartEfConsoleApp
{
    class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext() { 
        }

        public ShoppingDbContext(string connectionString) : base(connectionString) { 
        
        }

        public DbSet<User>  Users{ get; set; }
        public DbSet<Item>  Items{ get; set; }
        public DbSet<Order>  Orders{ get; set; }
        public DbSet<Cart>  Carts{ get; set; }
    }
}
