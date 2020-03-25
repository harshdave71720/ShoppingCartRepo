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
        private IRepository<Cart> DataSource = new CartRepository(new ShoppingDbContext("ShoppingCartDatabase"));
       
        [HttpGet]
        public IHttpActionResult AllCarts() {
            var some = DataSource.GetAll().ToList();
            //return Ok(DataSource.GetAll().ToList());
            return Ok(some);
        }

        [HttpGet]
        public IHttpActionResult EmptyCart(Guid id) {
            Cart cart = DataSource.Find(new Cart { Id = id});
            if (cart == null) {
                return BadRequest("Cart not found");
            }
            if (cart.Status == CartStatus.Completed) {
                return BadRequest("Cannot empty completed part");
            }
            cart.EmptyCart();
            DataSource.Remove(cart);
            DataSource.SaveChanges();
            return Ok(cart);
        }

        
    }
}
