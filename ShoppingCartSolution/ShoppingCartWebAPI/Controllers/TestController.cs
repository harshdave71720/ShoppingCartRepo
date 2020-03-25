using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Controllers
{
    public class TestController : ApiController
    {
        public IHttpActionResult Get() {
            using (ShoppingDbContext context = new ShoppingDbContext("ShoppingCartDatabase")) {
                context.Items.Add(new Item { Price = 1});
                context.Items.Add(new Item { Price = 1});
                context.Items.Add(new Item { Price = 1});
                context.SaveChanges();
            }
            return Ok("done");
        }
    }
}
