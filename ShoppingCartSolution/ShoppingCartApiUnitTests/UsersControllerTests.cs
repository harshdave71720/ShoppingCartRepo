using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShoppingCartWebAPI.Repositories;
using ShoppingCartWebAPI.Controllers;
using ShoppingCartLibrary;
using System.Net.Http;
using System.Web.Http.Results;

namespace ShoppingCartApiUnitTests
{
    [TestFixture]
    public class UsersControllerTests
    {
        [Test]
        public void RemoveExistingUserPassess() {
            //arrange
            var dataSource = ShoppingSetupFixture.DataSource.Object;
            var controller = new UsersController(dataSource);
            User user = new User() { Id = Guid.NewGuid()};
            ShoppingSetupFixture.Users.Add(user);
            var r = dataSource.Users.Remove(user);
            //act
            var result = controller.Remove(user.Id) as OkNegotiatedContentResult<User>;

            //assert
            Assert.IsNotNull(result.Content);
        }
        
        [Test]
        public void RemoveNotExistingUserFails() {
            //arrange
            var dataSource = ShoppingSetupFixture.DataSource.Object;
            var controller = new UsersController(dataSource);
            User user = new User() { Id = Guid.NewGuid() };

            //act
            var result = controller.Remove(user.Id);

            //assert
            //Assert.IsNull(result.);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void ConfirmCart_NotExistingUserFails() {
            //arrange
            var dataSource = ShoppingSetupFixture.DataSource.Object;
            var controller = new UsersController(dataSource);

            //act
            var result = controller.ConfirmCart(new User() { Id = Guid.NewGuid()}.Id);

            //assert
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
        }

        [Test]
        public void ConfirmCart_EmptyCartFails() {
            //arrange
            var dataSource = ShoppingSetupFixture.DataSource.Object;
            var controller = new UsersController(dataSource);
            User user = new User() { Id = Guid.NewGuid() };
            ShoppingSetupFixture.Users.Add(user);
            //act
            var result = controller.ConfirmCart(user.Id);

            //assert
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
        }
    }
}
