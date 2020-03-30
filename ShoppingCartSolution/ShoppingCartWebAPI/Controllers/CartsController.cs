using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartLibrary;
using ShoppingCartWebAPI.Repositories;

namespace ShoppingCartWebAPI.Controllers
{
    public class CartsController : ApiController
    {
        //private IRepository<Cart> DataSource;// = new CartRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        //private IRepository<Item> ItemDataSource;// = new CartRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        private IDataSource DataSource;// = new ShoppingDataSource();
        public CartsController() {
            DataSource = new ShoppingDataSource();
        }

        public CartsController(IDataSource dataSource) {
            DataSource = dataSource;
        }

        [HttpGet]
        public IHttpActionResult AllCarts() {
            var some = DataSource.Carts.GetAll().ToList();
            //return Ok(DataSource.GetAll().ToList());
            return Ok(some);
        }

        

        [HttpGet]
        public IHttpActionResult EmptyCart(Guid id) {
            Cart cart = DataSource.Carts.Find(new Cart { Id = id});
            if (cart == null) {
                return BadRequest("Cart not found");
            }
            if (cart.Status == CartStatus.Completed) {
                return BadRequest("Cannot empty completed part");
            }
            cart.EmptyCart();
            DataSource.Carts.Remove(cart);
            DataSource.Carts.SaveChanges();
            return Ok(cart);
        }

        [HttpGet]
        public IHttpActionResult AddToModified(Guid itemId, [FromBody] Guid cartId) {
            var cart = DataSource.Carts.Find(new Cart { Id = cartId});
            var item = DataSource.Items.Find(new Item { Id = itemId});
            if (cart == null || item == null) {
                return NotFound();
            }

            if (cart.Status != CartStatus.Active) {
                return BadRequest("Cart is not active for modification");
            }
            if (cart.Add(item, 1) < 0) {
                return BadRequest("Item not available right now");
            }
            DataSource.SaveChanges();
            return Ok(cart);
            
        }

        [HttpGet]
        public IHttpActionResult RemoveFromModified(Guid itemId,[FromBody]Guid cartId) {
            var cart = DataSource.Carts.Find(new Cart { Id = cartId });
            var item = DataSource.Items.Find(new Item { Id = itemId });
            if (cart == null || item == null)
            {
                return NotFound();
            }

            if (cart.Status != CartStatus.Active)
            {
                return BadRequest("Cart is not active for modification");
            }

            if (cart.Remove(item, 1) < 0) {
                return BadRequest("Item does not exist in cart");                    
            }
            DataSource.SaveChanges();
            return Ok(cart);
        }

        [HttpGet]
        public IHttpActionResult ConfirmModifiedCart(Guid cartId) {
            Cart cart = DataSource.Carts.Find(new Cart { Id = cartId});

            if (cart == null) {
                return BadRequest("Cart not found");
            }

            if (cart.Status != CartStatus.Active) {
                return BadRequest("Cannot confirm completed cart");
            }

            if (cart.CartItems == null || cart.CartItems.Count == 0) {
                return BadRequest("Cannot confirm empty cart");
            }
            if (cart.Order == null) {
                return BadRequest("no corresponding order found");
            }

            cart.Status = CartStatus.Completed;
            cart.Order.Status = OrderStatus.Recieved;
            DataSource.SaveChanges();
            return Ok(cart.Order);
        }
    }
}
