using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDataLayer.DataStores
{
    public class CartDataStore
    {
        private ICartRepository CartRepository;
        private ICartItemRepository CartItemRepository;

        public CartDataStore(ICartRepository cartRepository, ICartItemRepository cartItemRepository) {
            this.CartRepository = cartRepository;
            this.CartItemRepository = cartItemRepository;
        }

        public Cart AddCart(Cart cart) {
            var cartItems = cart.CartItems;
            cart.CartItems = null;
            CartRepository.Add(cart);
            if (cartItems != null) {
                foreach (var cartItem in cartItems) {
                    CartItemRepository.Add(cartItem);
                }
            }
            return cart;
        }

        public Cart GetCart(Guid userId, Guid cartId)
        {
            Cart cart = CartRepository.GetUserCart(userId, cartId);            
            if (cart == null) {
                return null;
            }
            cart.CartItems = new List<CartItem>();
            List<CartItem> cartItems = CartItemRepository.GetAll(cartId).ToList();
            if(cartItems != null)
                cart.CartItems = cartItems;
            return cart;
        }

        public int AddItemToCart(Cart cart, Item item, int quantity)
        {
            var cartItem = CartItemRepository.Find(new CartItem { CartId = cart.Id, ItemId = item.Id});
            
            if (cartItem != null) {
                cartItem.Quantity += quantity;
                CartItemRepository.Update(cartItem);
                CartRepository.UpdatePrice(cart.Id, cart.TotalPrice + quantity * item.Price);
                return quantity;
            }
            CartItemRepository.Add(new CartItem { CartId = cart.Id, ItemId = item.Id, Quantity = quantity});
            CartRepository.UpdatePrice(cart.Id, cart.TotalPrice + quantity * item.Price);
            return quantity;
        }

        public List<Cart> GetCarts(Guid userId)
        {
            List<Cart> carts = CartRepository.GetUserCarts(userId).ToList();
            if (carts == null) {
                return new List<Cart>();
            }
            foreach (var cart in carts) {
                cart.CartItems = new List<CartItem>();
                List<CartItem> cartItems = CartItemRepository.GetAll(cart.Id).ToList();
                if (cartItems != null)
                    cart.CartItems = cartItems;
            }
            return carts;
        }

        public object Find(Cart cart)
        {
            throw new NotImplementedException();
        }

        public int RemoveItemFromCart(Cart cart, Item item, int quantity)
        {
            var cartItem = CartItemRepository.Find(new CartItem { CartId = cart.Id, ItemId = item.Id});
            if (cartItem == null) {
                return 0;
            }
            
            if (quantity >= cartItem.Quantity) {
                CartItemRepository.Remove(cartItem);
                CartRepository.UpdatePrice(cart.Id, cart.TotalPrice - cartItem.Quantity * item.Price);
                return cartItem.Quantity;
            }
            cartItem.Quantity -= quantity;
            CartRepository.UpdatePrice(cart.Id, cart.TotalPrice - quantity * item.Price );
            CartItemRepository.Update(cartItem);
            return quantity;
        }

        public void UpdateCartStatus(Guid cartId, CartStatus status)
        {
            //var cart = CartRepository.Find(new Cart { Id = cartId});
            //if (cart == null) {
            //    return;
            //}
            //cart.Status = status;
            CartRepository.UpdateStatus(cartId, status);
        }

        public Cart GetActiveCart(Guid userId) {
            var cart = CartRepository.GetUserCarts(userId).SingleOrDefault(c => c.Status == CartStatus.Active);
            if (cart == null) {
                cart = new Cart() { Status = CartStatus.Active, UserId = userId };
                return CartRepository.Add(cart);               
            }

            cart.CartItems = CartItemRepository.GetAll(cart.Id).ToList();
            return cart;
        }

        
    }
}
