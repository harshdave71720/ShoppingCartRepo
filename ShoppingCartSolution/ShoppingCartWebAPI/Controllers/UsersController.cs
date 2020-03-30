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
    public class UsersController : ApiController
    {
        //private IRepository<User> DataSource = new UserRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        private IDataSource DataSource;

        public UsersController() {
            DataSource = new ShoppingDataSource();
        }

        public UsersController(IDataSource dataSource) {
            DataSource = dataSource;
        }

        [HttpPost]
        public IHttpActionResult Add(User user) {
            return Ok(DataSource.Users.Add(user));
        }

        [HttpGet]
        public IHttpActionResult GetAll() {
            return Ok(DataSource.Users.GetAll().ToList());
        }

        [HttpDelete]
        public IHttpActionResult Remove(Guid id) {
            User user = DataSource.Users.Remove(new User { Id = id });
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IHttpActionResult ConfirmCart(Guid userId) {
            var user = DataSource.Users.Find(new User { Id = userId});
            if (user == null) {
                return BadRequest("User not found");
            }
       
            if (user.GetActiveCart().CartItems == null) {
                return BadRequest("cannot confirm empty cart");
            }
            var order = user.GetActiveCart().PlaceOrder();
            DataSource.Users.SaveChanges();
            return Ok(order);

        }

        [HttpGet]
        public IHttpActionResult ConfirmOrderDelivery(Guid orderId) {
            Order order = DataSource.Orders.Find(new Order { Id = orderId });
            if (order == null)
            {
                return NotFound();
            }
            if (order.Status != OrderStatus.Dispatched || order.Status != OrderStatus.Recieved) {
                return BadRequest("Cannot confirm delivery of active or cancelled order");
            }

            order.Status = OrderStatus.Delivered;
            DataSource.SaveChanges();
            return Ok();
        }
    }
}
