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
    public class ItemsController : ApiController
    {
        public IRepository<Item> DataSource;

        public ItemsController(IRepository<Item> repository) {
            DataSource = repository;
        }

        //public IHttpActionResult Add(Item item) {
        //    Item temp = DataSource.Find(item);
        //    if () { 
            
        //    }                                       
        //}
    }
}
