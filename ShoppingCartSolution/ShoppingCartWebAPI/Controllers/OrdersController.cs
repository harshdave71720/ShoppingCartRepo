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
        private IHttpActionResult GetAll(Guid userId) {
            return Ok(DataSource.Users.Find(userId).Orders);
        }
        
    }
}
