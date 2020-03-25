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
        private IRepository<User> DataSource = new UserRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        
        [HttpPost]
        public IHttpActionResult Add(User user) {
            return Ok(DataSource.Add(user));
        }

        [HttpGet]
        public IHttpActionResult GetAll() {
            return Ok(DataSource.GetAll().ToList());
        }

        [HttpDelete]
        public IHttpActionResult Remove(Guid id) {
            return Ok(DataSource.Remove(new User { Id = id}));
        }

        [HttpGet]
        public IHttpActionResult ConfirmCart(Guid userId) {
            var user = DataSource.Find(new User { Id = userId});
            if (user == null) {
                return BadRequest("User not found");
            }
            if (user.GetActiveCart().CartItems == null) {
                return BadRequest("No Active cart found");
            }
            var order = user.GetActiveCart().PlaceOrder();
            DataSource.SaveChanges();
            return Ok(order);

        }
    }
}
