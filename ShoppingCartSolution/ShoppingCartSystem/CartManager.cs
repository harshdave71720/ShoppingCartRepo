using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    public class CartManager : ShoppingSystemManager
    {
        public CartManager(IDataSource dataSource) : base(dataSource){}

        public Cart GetCart(Guid userId, Guid cartId)
        {
            Cart cart = DataSource.Carts.GetUserCart(userId, cartId);
            return cart;
        }

        public List<Cart> GetCarts(Guid userId)
        {
            List<Cart> carts = DataSource.Carts.GetUserCarts(userId).ToList();

            return carts;
        }

        public Order ConfirmCartToOrder(Guid userId, Guid cartId)
        {
            Cart cart = DataSource.Carts.Find(new Cart { Id = cartId });

            if (cart == null || !cart.User.Id.Equals(userId))
            {
                return null;
            }
            var order = cart.PlaceOrder();
            DataSource.SaveChanges();
            return order;

        }

        public CartItem AddItemToUserCart(Guid userId, Guid cartId, Guid itemId, int quantity)
        {
            var cart = DataSource.Carts.Find(new Cart { Id = cartId });
            var item = DataSource.Items.Find(new Item { Id = itemId });
            if (item == null || cart == null || !cart.User.Id.Equals(userId))
            {
                return null;
            }
            quantity = cart.Add(item, quantity);
            DataSource.SaveChanges();
            return new CartItem() { Item = item, ItemId = item.Id, Quantity = quantity };
        }

        public CartItem RemoveItemFromUserCart(Guid userId, Guid cartId, Guid itemId, int quantity)
        {
            var cart = DataSource.Carts.Find(new Cart { Id = cartId });
            var item = DataSource.Items.Find(new Item { Id = itemId });
            if (item == null || cart == null || !cart.User.Id.Equals(userId))
            {
                return null;
            }
            quantity = cart.Remove(item, quantity);
            DataSource.SaveChanges();
            return new CartItem() { Item = item, ItemId = item.Id, Quantity = quantity };
        }

        public Order ConfirmCart(Guid userId, Guid cartId)
        {
            var cart = DataSource.Carts.Find(new Cart { Id = cartId });
            if (cart == null || !cart.User.Id.Equals(userId))
            {
                return null;
            }
            return cart.PlaceOrder();
        }
    }
}
