using ShoppingCartEFDataLayer.Repositories;
using ShoppingCartSystem;
using ShoppingSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingSystemWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        private OrderManager Manager;

        public OrderController()
        {
            Manager = new OrderManager(new ShoppingDataSource());
        }

        public OrderController(OrderManager manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public IHttpActionResult Get(UserOrderModel userOrder) {
            var order = Manager.GetOrder(userOrder.UserId, userOrder.OrderId);

            if (order == null) {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public IHttpActionResult GetAll(Guid userId) {
            var orders = Manager.GetOrders(userId);

            return Ok(orders);
        }

        [HttpGet]
        public IHttpActionResult Modify(UserOrderModel model) {
            return Ok(Manager.ModifyOrder(model.UserId, model.OrderId));
        }
    }
}
