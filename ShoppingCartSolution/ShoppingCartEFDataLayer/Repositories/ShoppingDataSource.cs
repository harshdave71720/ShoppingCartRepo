using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class ShoppingDataSource : IDataSource
    {
        public ShoppingDataSource(ItemRepository items,
            CartRepository carts,
            UserRepository users,
            OrderRepository orders) {
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
        
        public IItemRepository Items { get; set; }
        public ICartRepository Carts { get; set; }
        public IUserRepository Users { get; set; }
        public IOrderRepository Orders { get; set; }

        public int SaveChanges()
        {
            return Items.SaveChanges() +
                Users.SaveChanges() +
                Orders.SaveChanges() +
                Carts.SaveChanges();
        }
    }
}