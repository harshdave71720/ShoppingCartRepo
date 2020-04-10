using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    public class OrderManager : ShoppingSystemManager
    {
        public OrderManager(IDataSource dataSource) : base(dataSource) { }

        public Order GetOrder(Guid userId, Guid orderId)
        {
            return DataSource.Orders.GetUserOrder(userId, orderId);
        }

        public List<Order> GetOrders(Guid userId)
        {
            var orders = DataSource.Orders.GetUserOrders(userId);
            if (orders ==  null) {
                return new List<Order>();
            }
            return orders.ToList();
        }

        public bool ModifyOrder(Guid userId, Guid orderId)
        {
            var order = DataSource.Orders.GetUserOrder(userId, orderId);
            if (order == null)
            {
                return false;
            }
            order.Modify();
            DataSource.SaveChanges();
            return true;
        }
        public bool OrderItemDelivered(Guid userId, Guid orderId, Guid itemId) {
            var order = DataSource.Orders.Find(new Order { Id = orderId});
            if (order == null || !order.User.Id.Equals(userId)) {
                return false;
            }
            var orderItem = order.OrderItems.FirstOrDefault(oi => oi.ItemId.Equals(itemId));
            if (orderItem == null) {
                return false;
            }
            orderItem.Status = ItemStatus.DELIVERED;
            return true;
        }
    }
}
