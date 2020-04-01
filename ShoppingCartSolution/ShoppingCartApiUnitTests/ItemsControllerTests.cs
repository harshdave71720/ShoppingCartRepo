using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;
using ShoppingCartWebAPI.Controllers;
using System.Web.Http.Results;
using NUnit.Framework;

namespace ShoppingCartApiUnitTests
{
    [TestFixture]
    class ItemsControllerTests
    {
        [Test]
        public void GetItem_NotExistingItemFails() {
            //arrange
            var item = new Item { Id = Guid.NewGuid()};
            var controller = new ItemsController(ShoppingSetupFixture.DataSource.Object);

            //act
            var result = controller.GetItem(item.Id);
            //assert

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetItem_ExistingItemPassess() {
            //arrange
            var item = new Item { Id = Guid.NewGuid() };
            var controller = new ItemsController(ShoppingSetupFixture.DataSource.Object);
            ShoppingSetupFixture.Items.Add(item);

            //act
            var result = controller.GetItem(item.Id);
            //assert

            Assert.IsInstanceOf<OkNegotiatedContentResult<Item>>(result);
        }

        [Test]
        public void AddExistingItem_NotExistingItemFails() {
            //arrange
            var item = new Item { Id = Guid.NewGuid() };
            var controller = new ItemsController(ShoppingSetupFixture.DataSource.Object);
            
            //act
            var result = controller.AddExistingItem(item.Id, 1);
            //assert

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void AddExistingItem_ExistingItemPassess() {
            //arrange
            var item = new Item { Id = Guid.NewGuid() };
            var controller = new ItemsController(ShoppingSetupFixture.DataSource.Object);
            ShoppingSetupFixture.Items.Add(item);
            //act
            var result = controller.AddExistingItem(item.Id, 10);
            //assert

            Assert.IsInstanceOf<OkNegotiatedContentResult<Item>>(result);
            Assert.AreEqual(10,((OkNegotiatedContentResult<Item>)result).Content.Quantity);
        }

        [Test]
        public void UpdateItem_NotExistingItemFails() {
            //arrange
            var item = new Item { Id = Guid.NewGuid() };
            var controller = new ItemsController(ShoppingSetupFixture.DataSource.Object);
            
            //act
            var result = controller.UpdateItem(item);
            //assert

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Trial() {
            //arrange
            var item = new Item { Id = Guid.NewGuid(), Name ="Myitemno1" };
            var controller = new ItemsController(ShoppingSetupFixture.DataSource.Object);
            ShoppingSetupFixture.Items.Add(item);
            //act
            var result = controller.GetItem(item.Id);
            //assert

            Assert.IsInstanceOf<NotFoundResult>(result);
            
        }
    }
}
