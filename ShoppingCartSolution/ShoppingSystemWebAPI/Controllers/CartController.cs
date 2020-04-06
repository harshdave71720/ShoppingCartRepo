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

namespace ShoppingSystemWebAPI.Controllers
{
    public class CartController : ApiController
    {
        private CartManager Manager;

        public CartController()
        {
            Manager = new CartManager(new ShoppingDataSource());
        }

        public CartController(CartManager manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public IHttpActionResult Get(UserCartModel userCart) {
            Cart cart = Manager.GetCart(userCart.UserId, userCart.CartId);

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

        [HttpGet]
        public IHttpActionResult ConfirmToOrder(UserCartModel cartModel) {
            Order order = Manager.ConfirmCartToOrder(cartModel.UserId, cartModel.CartId);

            if (order == null)
            {
                return NotFound();                    
            }
            return Ok(order);
        }

        [HttpGet]
        public IHttpActionResult AddItem(Guid userId, CartItem cartItem) {
            CartItem result = Manager.AddItemToUserCart(userId, cartItem.CartId, cartItem.ItemId, cartItem.Quantity);

            if (result == null) {
                return NotFound();
            }
            return Ok("Added " + result.Quantity);
        }

        [HttpGet]
        public IHttpActionResult RemoveItem(Guid userId, CartItem cartItem) {
            CartItem result = Manager.RemoveItemFromUserCart(userId, cartItem.CartId, cartItem.ItemId, cartItem.Quantity);

            if (result == null) {
                return NotFound();
            }

            return Ok("Removed " + result.Quantity);
        }

        [HttpGet]
        public IHttpActionResult Confirm(UserCartModel userCart) {
            Order order = Manager.ConfirmCart(userCart.UserId, userCart.CartId);

            if (order == null) {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
