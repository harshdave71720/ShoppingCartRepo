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
        
        [HttpPost]
        public IHttpActionResult Add(Cart cart) {
            return Ok(DataSource.Add(cart));   
        }
    }
}
