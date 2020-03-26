﻿using System;
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

        private IRepository<Item> DataSource;// = new ItemRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        private IRepository<User> UserDataSource;// = new UserRepository(new ShoppingDbContext("ShoppingCartDatabase"));

        public ItemsController()
        {
            ShoppingDbContext context = new ShoppingDbContext("ShoppingCartDatabase");
            DataSource = new ItemRepository(context);
            UserDataSource = new UserRepository(context);

        }

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

        [HttpPost]
        public IHttpActionResult AddToCart(Guid itemId, [FromBody] Guid userId) {
            var user = UserDataSource.Find(new User { Id = userId });
            var item = DataSource.Find(new Item { Id = itemId });
            Cart cart = user.GetActiveCart();
            if (cart.Add(item, 1) < 0) {
                return BadRequest("Item out of Stock");
            }
            DataSource.SaveChanges();
            return Ok(item);
        }

    }
}
