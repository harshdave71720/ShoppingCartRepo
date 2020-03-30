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
    public class OrdersController : ApiController
    {
        //private ShoppingDbContext DataSource = new ShoppingDbContext("ShoppingCartDatabase");
        private IDataSource DataSource;// = new ShoppingDataSource();

        public OrdersController() {
            DataSource = new ShoppingDataSource();
        }
        public OrdersController(IDataSource dataSource) {
            DataSource = dataSource;
        }

        [HttpGet]
        public IHttpActionResult GetAll(Guid userId) {
            return Ok(DataSource.Users.Find(new User { Id = userId}).Orders);
        }

        [HttpGet]
        public IHttpActionResult Modify(Guid id) {
            Order order = DataSource.Orders.Find(new Order { Id = id});
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
