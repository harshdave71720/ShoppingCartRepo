//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using ShoppingCartLibrary;
//using ShoppingCartWebAPI.Controllers;
//using ShoppingCartWebAPI.Repositories;
//using System.Web.Http.Results;

//namespace ShoppingCartApiUnitTests
//{
//    [TestFixture]
//    class OrdersControllerTests
//    {
//        [Test]
//        public void Modify_NotExistingOrderFails() {
//            //arrange
//            var controller = new OrdersController(ShoppingSetupFixture.DataSource.Object);
//            var order = new Order { Id = Guid.NewGuid()};

//            //act
//            var result = controller.Modify(order.Id);

//            //assert
//            Assert.IsInstanceOf<NotFoundResult>(result);
//        }

//        [Test]
//        public void Modify_ModifyingDeliveredOrderFails() {
//            //arrange
//            var controller = new OrdersController(ShoppingSetupFixture.DataSource.Object);
//            var order = new Order { Id = Guid.NewGuid(), Status = OrderStatus.Delivered };
//            ShoppingSetupFixture.Orders.Add(order);

//            //act
//            var result = controller.Modify(order.Id);

//            //assert
//            //Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
//        }

//        [Test]
//        public void Modify_ModifyingRecievedOrderPassess(){

//        }
//    }
//}
