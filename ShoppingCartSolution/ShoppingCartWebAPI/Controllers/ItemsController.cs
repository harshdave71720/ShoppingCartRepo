using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartLibrary;
using ShoppingCartWebAPI.Models;

namespace ShoppingCartWebAPI.Controllers
{
    public class ItemsController : ApiController
    {
        public IHttpActionResult Get() {

            //ShoppingDbContext context = new ShoppingDbContext("ShoppingCartDatabase");
            //context.Items.Add(new Item { Id = "item1" , Price = 100, Quantity = 100});

            //return Ok(context.Items);
            return BadRequest();               
        }
    }
}
