using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private ShoppingDbContext DataSource = new ShoppingDbContext("ShoppingCartDatabase");

        [HttpGet]
        public IHttpActionResult GetAll(Guid userId) {
            return Ok(DataSource.Users.Find(userId).Orders);
        }

        [HttpGet]
        public IHttpActionResult Modify(Guid id) {
            Order order = DataSource.Orders.Find(id);
            if (order == null) {
                return NotFound();
            }

            if (order.Status == OrderStatus.Delivered) {
                return BadRequest("Cannot modify a delivered order");
            }
            order.Status = OrderStatus.Changed;
            order.Cart.Status = CartStatus.Active;
            DataSource.SaveChanges();
            return Ok(order.Cart);
        }
    }
}
