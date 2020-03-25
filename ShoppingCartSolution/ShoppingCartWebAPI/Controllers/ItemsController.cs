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
        public IRepository<Item> DataSource = new ItemRepository(new ShoppingDbContext("ShoppingCartDatabase"));

        //public ItemsController(IRepository<Item> repository) {
        //    DataSource = repository;
        //}
        [HttpPost]
        public IHttpActionResult Add(Item item) {
            return Ok(DataSource.Add(item));
        }

        [HttpGet]
        public IHttpActionResult GetItem([FromBody]Guid id)
        {            
            return Ok(DataSource.Find(new Item { Id = id }));
        }

        [HttpGet]
        public IHttpActionResult AllItems() {
            return Ok(DataSource.GetAll().ToList());
        }

        [HttpGet]
        public IHttpActionResult AddExistingItem(Guid id, [FromBody] int quantity) {
            var item = DataSource.Find(new Item { Id = id });
            item.Quantity += quantity;
            DataSource.Update(item);
            return Ok(item);
        }

        [HttpPut]
        public IHttpActionResult UpdateItem(Item item) {
            return Ok(DataSource.Update(item));
        }
    }
}
