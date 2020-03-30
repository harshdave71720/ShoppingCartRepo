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

        //private IRepository<Item> DataSource;// = new ItemRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        //private IRepository<User> UserDataSource;// = new UserRepository(new ShoppingDbContext("ShoppingCartDatabase"));
        private IDataSource DataSource;

        public ItemsController() {
            DataSource = new ShoppingDataSource();
        }

        public ItemsController(IDataSource dataSource)
        {
            DataSource = dataSource;
        }

        [HttpPost]
        public IHttpActionResult Add(Item item) {
            return Ok(DataSource.Items.Add(item));
        }

        [HttpGet]
        public IHttpActionResult GetItem([FromBody]Guid id)
        {
            var item = DataSource.Items.Find(new Item { Id = id });
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public IHttpActionResult AllItems() {
            return Ok(DataSource.Items.GetAll().ToList());
        }

        [HttpGet]
        public IHttpActionResult AddExistingItem(Guid id, [FromBody] int quantity) {
            var item = DataSource.Items.Find(new Item { Id = id });
            if (item == null) {
                return NotFound();
            }
            item.Quantity += quantity;
            DataSource.Items.Update(item);
            return Ok(item);
        }

        [HttpPut]
        public IHttpActionResult UpdateItem(Item item) {
            var item1 = DataSource.Items.Update(item);
            if (item1 == null) {
                return NotFound();
            }
            return Ok(item1);
        }

        [HttpPost]
        public IHttpActionResult AddToCart(Guid itemId, [FromBody] Guid userId) {
            var user = DataSource.Users.Find(new User { Id = userId });
            if (user == null) {
                return NotFound();
            }         
            var item = DataSource.Items.Find(new Item { Id = itemId });
            if (item == null) {
                return NotFound();
            }
            Cart cart = user.GetActiveCart();
            if (cart.Add(item, 1) < 0) {
                return BadRequest("Item out of Stock");
            }
            DataSource.SaveChanges();
            return Ok(item);
        }

    }
}
