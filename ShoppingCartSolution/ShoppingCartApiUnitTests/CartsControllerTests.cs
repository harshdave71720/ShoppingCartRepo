using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using ShoppingCartWebAPI.Controllers;
using ShoppingCartLibrary;
using NUnit.Framework;

namespace ShoppingCartApiUnitTests
{
    [TestFixture]
    class CartsControllerTests
    {
        [Test]
        public void EmptyCart_NotExistingCartFails() {
            //arrange
            var controller = new CartsController(ShoppingSetupFixture.DataSource.Object);
            var cart = new Cart() { Id = Guid.NewGuid()};
            //act
            var result = controller.EmptyCart(cart.Id);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void EmptyCart_CompletedCartFails() {
            //arrange
            var controller = new CartsController(ShoppingSetupFixture.DataSource.Object);
            var cart = new Cart() { Id = Guid.NewGuid() };
            ShoppingSetupFixture.Carts.Add(cart); 
            
            //act
            var result = controller.EmptyCart(cart.Id);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void AddToModified_NotExistingCartFails() {
            //arrange
            var controller = new CartsController(ShoppingSetupFixture.DataSource.Object);
            var cart = new Cart() { Id = Guid.NewGuid() };
            var item = new Item() { Id = Guid.NewGuid() };
            ShoppingSetupFixture.Items.Add(item); 
            //act
            var result = controller.AddToModified(item.Id, cart.Id);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void AddToModified_NotExistingItemFails()
        {
            //arrange
            var controller = new CartsController(ShoppingSetupFixture.DataSource.Object);
            var cart = new Cart() { Id = Guid.NewGuid() };
            var item = new Item() { Id = Guid.NewGuid() };
            ShoppingSetupFixture.Carts.Add(cart);
            //act
            var result = controller.AddToModified(item.Id, cart.Id);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void RemoveFromModified() { 
        
        }
    }
}
