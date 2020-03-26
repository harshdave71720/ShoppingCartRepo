using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Repositories
{
    public interface IDataSource
    {
        IRepository<Item> Items { get; set; }
        IRepository<Cart> Carts { get; set; }
        IRepository<User> Users { get; set; }
        IRepository<Order> Orders { get; set; }
        //IRepository<Item> CartItems { get; set; }
        int SaveChanges();
        
    }
}
