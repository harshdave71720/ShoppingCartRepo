using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartDataLayer.Repositories
{
    public interface IDataSource
    {
        IItemRepository Items { get; set; }
        ICartRepository Carts { get; set; }
        IUserRepository Users { get; set; }
        
        IOrderRepository Orders { get; set; }
        
        //IRepository<Item> CartItems { get; set; }
        int SaveChanges();
        
    }
}
