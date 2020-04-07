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
using ShoppingSystemWebAPI.Filters;

namespace ShoppingSystemWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserManager Manager; 
            
        public UserController() {
            Manager = new UserManager(new ShoppingDataSource());
        }

        public UserController(UserManager manager) {
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

            return Ok(new UserModel(user));
        }

        //[HttpGet]
        ////[ApiExceptionHandler]
        //public IHttpActionResult Test() {
        //    throwException1();
        //    return null;
        //}

        //private void throwException1() {
        //    throwException2();
        //}

        //private void throwException2() {
        //    throw new Exception("Something happened");
        //}
    }
}
