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
using ShoppingSystemWebAPI.Authentication;
using KeyBasedAuthenticator.DataBaseLayer;
using KeyBasedAuthenticator.Models;

namespace ShoppingSystemWebAPI.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : ApiController
    {
        private UserManager Manager; 
        private IAuthRepository AuthRepository;
            
        public UserController() {
            Manager = new UserManager(new ShoppingDataSource());
            AuthRepository = new AuthRepository();
        }

        public UserController(UserManager manager) {
            Manager = manager;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id) {
            var user1 = RequestContext.Principal.Identity.Name;
            User user = Manager.GetUser(id);
            if (user == null) {
                return NotFound();
              }
            return Ok(new UserModel(user));
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Add(UserModel user) {
            var resultUser = Manager.AddUser(user.ToUser());
            var AuthUser = AuthRepository.AddAppUser(new AppUser { Id = resultUser.Id, PrivateKey = Guid.NewGuid()});
            return Ok(new AuthUserResultModel(AuthUser));
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
