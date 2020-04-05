using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartSystem;
using ShoppingCartEFDataLayer.Repositories;
using ShoppingSystemWebAPI.Models;
using ShoppingCartLibrary;

namespace ShoppingSystemWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private ShoppingSystemManager Manager; 
            
        public UserController() {
            Manager = new ShoppingSystemManager(new ShoppingDataSource());
        }

        public UserController(ShoppingSystemManager manager) {
            Manager = manager;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id) {
            User user = Manager.GetUser(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(new UserModel(user));
        }

        [HttpPost]
        public IHttpActionResult Add(UserModel user) {
            return Ok(Manager.AddUser(user.ToUser()));
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id) {
            User user = Manager.RemoveUser(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public IHttpActionResult Update(UserModel userModel) {
            User user = Manager.UpdateUser(userModel.ToUser());

            if (user == null) {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
