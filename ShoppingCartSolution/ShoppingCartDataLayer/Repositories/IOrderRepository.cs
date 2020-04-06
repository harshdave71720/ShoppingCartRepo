using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartDataLayer.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetUserOrders(Guid userId);

        IEnumerable<OrderItem> GetOrderItems(Guid userId, Guid orderId);

        Order GetUserOrder(Guid userId, Guid orderId);
    }
}
