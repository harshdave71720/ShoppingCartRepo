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
            return DataSource.Orders.GetUserOrders(userId).ToList();
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
    }
}
