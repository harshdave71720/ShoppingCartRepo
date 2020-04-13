using ShoppingCartEFDataLayer.Repositories;
using ShoppingCartLibrary;
using ShoppingCartSystem;
using ShoppingSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartEFDataLayer.Factories;
using ShoppingCartDataLayer.Factories;

namespace ShoppingSystemWebAPI.Controllers
{
    public class CartController : ApiController
    {
        private CartManager Manager;

        public CartController()
        {
            Manager = new CartManager(DataStoreFactory.CreateCartDataStore());
        }

        public CartController(CartManager manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid userId, Guid cartId) {
            Cart cart = Manager.GetCart(userId, cartId);

            if (cart == null) {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpGet]
        public IHttpActionResult GetAll(Guid userId) {
            List<Cart> carts = Manager.GetCarts(userId);

            if (carts == null || carts.Count == 0) {
                return Ok("No Carts to show right now");
            }
            return Ok(carts);
        }

        [HttpPost]
        public IHttpActionResult ConfirmToOrder(UserCartModel cartModel) {
            Order order = Manager.ConfirmCart(cartModel.UserId, cartModel.CartId);

            if (order == null)
            {
                return NotFound();                    
            }
            return Ok(order);
        }

        [HttpPost]
        public IHttpActionResult AddItem(Guid userId, CartItemModel cartItem) {
            CartItem result = Manager.AddItemToCart(userId, cartItem.CartId, cartItem.ItemId, cartItem.Quantity);

            if (result == null) {
                return NotFound();
            }
            return Ok("Added " + result.Quantity);
        }

        [HttpDelete]
        public IHttpActionResult RemoveItem(Guid userId, CartItemModel cartItem) {
            CartItem result = Manager.RemoveItemFromCart(userId, cartItem.CartId, cartItem.ItemId, cartItem.Quantity);

            if (result == null) {
                return NotFound();
            }

            return Ok("Removed " + result.Quantity);
        }

        [HttpPost]
        public IHttpActionResult Confirm(UserCartModel userCart) {
            Order order = Manager.ConfirmCart(userCart.UserId, userCart.CartId);

            if (order == null) {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IHttpActionResult AddToActiveCart(UserItemModel userItem) {
            return Ok(Manager.AddItemToActiveCart(userItem.UserId, userItem.ItemId, userItem.Quantity));
        }
    }
}
