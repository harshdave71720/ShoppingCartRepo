using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Repositories
{
    public class ShoppingDataSource : IDataSource
    {
        public ShoppingDataSource(IRepository<Item> items,
            IRepository<Cart> carts,
            IRepository<User> users,
            IRepository<Order> orders) {
            Items = items;
            Carts = carts;
            Users = users;
            Orders = orders;
        }

        public ShoppingDataSource() {
            ShoppingDbContext context = ShoppingDbContextFactory.GetInstance();
            Items = new ItemRepository(context);
            Carts = new CartRepository(context);
            Users = new UserRepository(context);
            Orders = new OrderRepository(context);
        }
        
        public IRepository<Item> Items { get; set; }
        public IRepository<Cart> Carts { get; set; }
        public IRepository<User> Users { get; set; }
        public IRepository<Order> Orders { get; set; }

        public int SaveChanges()
        {
            return Users.SaveChanges();
        }
    }
}