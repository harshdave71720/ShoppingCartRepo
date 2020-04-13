using ShoppingCartEFDataLayer.Repositories;
using ShoppingCartLibrary;
using ShoppingCartSystem;
using ShoppingSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartDataLayer.Factories;

namespace ShoppingSystemWebAPI.Controllers
{
    [Authorize(Roles = "User")]
    public class ItemController : ApiController
    {
        private ItemManager Manager;

        public ItemController()
        {
            Manager = new ItemManager(DataStoreFactory.CreateItemDataStore());
        }

        public ItemController(ItemManager manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id) {
            Item item = Manager.GetItem(id);
            if (item == null) {
                return NotFound();
            }

            return Ok(new ItemModel(item));
        }

        [HttpPost]
        public IHttpActionResult Add(ItemModel item) {
            return Ok(Manager.AddItem(item.ToItem()));
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            Item item = Manager.RemoveItem(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut]
        public IHttpActionResult Update(ItemModel itemModel) {
            Item item = Manager.UpdateItem(itemModel.ToItem());

            if (item == null) {
                return NotFound();
            }

            return Ok(new ItemModel(item));
        }

        //there is some minor return value problem
        //[HttpPost]
        //public IHttpActionResult AddToCart(UserItemModel model) {
        //    if (model.Quantity <= 0) {
        //        return BadRequest("Cannot add 0 or negative quantity");
        //    }
        //    var cartItem = Manager.AddItemToCart(model.UserId, model.ItemId, model.Quantity);

        //    if (cartItem == null)
        //    {
        //        return BadRequest("Item Not Found");
        //    }
        //    return Ok("Added " + cartItem.Quantity);
            
        //}

        [HttpGet]
        public IHttpActionResult GetAll() {
            return Ok(Manager.GetItems());
        }

        [HttpGet]
        public IHttpActionResult test(AddItemModel model) {
            return null;
        }
    }
}
