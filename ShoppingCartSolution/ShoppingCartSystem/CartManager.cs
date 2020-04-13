using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDataLayer.DataStores;
using ShoppingCartDataLayer.Factories;
using System.Xml;
using System.Data;
using System.Data.SqlTypes;

namespace ShoppingCartSystem
{
    public class CartManager
    {
        private CartDataStore CartStore;
        public CartManager(CartDataStore dataStore) {
            this.CartStore = dataStore;
        } 

        public Cart GetCart(Guid userId, Guid cartId)
        {
            Cart cart = CartStore.GetCart(userId, cartId);
            return cart;
        }

        public List<Cart> GetCarts(Guid userId)
        {
            List<Cart> carts = CartStore.GetCarts(userId).ToList();

            return carts;
        }

        

        public CartItem AddItemToCart(Guid userId, Guid cartId, Guid itemId, int quantity)
        {
            if (quantity <= 0) {
                throw new InvalidOperationException("Cannot Add 0 or negative Quantity");
            }
         
            var cart = CartStore.GetCart(userId, cartId);
            
            var item = DataStoreFactory.CreateItemDataStore().Get(new Item { Id = itemId});
            if (item == null || cart == null)
            {
                return null;
            }
            if (cart.Status == CartStatus.Completed || cart.Status == CartStatus.Recieved) {
                throw new InvalidOperationException("Cart not marked for modification");
            }
            quantity = CartStore.AddItemToCart(cart, item, quantity);
            //quantity = cart.Add(item, quantity);
            //CartStore.SaveChanges();
            return new CartItem() { Item = item, ItemId = item.Id, Quantity = quantity };            
        }

        public CartItem RemoveItemFromCart(Guid userId, Guid cartId, Guid itemId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Cannot Add 0 or negative Quantity");
            }
            var cart = CartStore.GetCart(userId, cartId);
            var item = DataStoreFactory.CreateItemDataStore().Get(new Item { Id = itemId });
            if (item == null || cart == null)
            {
                return null;
            }
            if (cart.Status == CartStatus.Completed || cart.Status == CartStatus.Recieved)
            {
                throw new InvalidOperationException("Cart not marked for modification");
            }
            quantity = CartStore.RemoveItemFromCart(cart, item, quantity);
            //quantity = cart.Remove(item, quantity);
            //CartStore.SaveChanges();
            return new CartItem() { Item = item, ItemId = item.Id, Quantity = quantity };
        }

        public Order ConfirmCart(Guid userId, Guid cartId)
        {
            
            var cart = CartStore.GetCart(userId, cartId);
                       
            if (cart == null )
            {
                throw new Exception("Cart does not exist");
            }

            if (cart.CartItems == null || cart.CartItems.Count == 0) {
                throw new InvalidOperationException("Cannot confirm empty cart");
            }

            if (!ValidateCart(cart)) {
                throw new Exception("cart not valid");
            }

            //decrease item quantity code will come here
            

            var orderStore = DataStoreFactory.CreateOrderDataStore();
            var orderManager =new OrderManager(DataStoreFactory.CreateOrderDataStore());
            if (orderStore.GetOrder(userId, cartId) != null) {
                return orderManager.ConfirmOrder(cart);
            }
            CartStore.UpdateCartStatus(cart.Id, CartStatus.Recieved);

            ItemManager itemManager = new ItemManager(DataStoreFactory.CreateItemDataStore());
            
            foreach (var cartItem in cart.CartItems)
            {
                itemManager.DecreaseItemQuantity(cartItem.ItemId, cartItem.Quantity);
            }

            return orderManager.AddOrder(cart);
            //var order = cart.PlaceOrder();
            //CartStore.SaveChanges();            
        }

        public Cart AddItemToActiveCart(Guid userId, Guid itemId, int quantity) {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Cannot Add 0 or negative Quantity");
            }
            var item = DataStoreFactory.CreateItemDataStore().Get(new Item { Id = itemId });
            if (item == null) {
                throw new Exception("Item not found");                    
            }
            var cart = CartStore.GetActiveCart(userId);
            CartStore.AddItemToCart(cart, item, quantity);
            return CartStore.GetActiveCart(userId);
        }

        public void UpdateCartStatus(Guid id, CartStatus status)
        {
            CartStore.UpdateCartStatus(id, status);
        }

        private bool ValidateCart(Cart cart) {
            var itemManager = new ItemManager(DataStoreFactory.CreateItemDataStore());
            foreach (CartItem cartItem in cart.CartItems) {
                var item = itemManager.GetItem(cartItem.ItemId);
                if (item.Quantity < cartItem.Quantity) {
                    throw new InvalidOperationException("Item " + item.Name + " Required " + cartItem.Quantity + " Available " + item.Quantity);
                }
            }
            return true;
        }

        //public Order ConfirmCartToOrder(Guid userId, Guid cartId)
        //{
        //    Cart cart = CartStore.Carts.Find(new Cart { Id = cartId });

        //    if (cart == null || !cart.User.Id.Equals(userId))
        //    {
        //        return null;
        //    }
        //    var order = cart.PlaceOrder();
        //    CartStore.SaveChanges();
        //    return order;

        //}
    }
}
