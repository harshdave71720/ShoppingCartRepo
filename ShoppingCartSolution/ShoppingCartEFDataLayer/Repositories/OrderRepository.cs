using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class OrderRepository : EFRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ShoppingDbContext context) : base(context) { }
        public Order Add(Order obj)
        {
            var order = Context.Orders.Add(obj);
            Context.SaveChanges();
            return order;
        }

        public Order Find(Order Obj)
        {
            return Context.Orders.Find(Obj.Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return Context.Orders;
        }

        public IEnumerable<OrderItem> GetOrderItems(Guid userId, Guid orderId)
        {
            var order = Context.Orders.SingleOrDefault(c => c.Id.Equals(orderId) && c.User.Id.Equals(userId));
            if (order == null || order.OrderItems == null || order.OrderItems.Count == 0)
            {
                return null;
            }

            return order.OrderItems;
        }

        

        public IEnumerable<Order> GetUserOrders(Guid userId)
        {
            var orders = Context.Orders.Where(c => c.User.Id.Equals(userId)).ToList();
            if (orders == null || orders.Count == 0)
            {
                return null;
            }
            return orders;
        }

        public Order Remove(Order obj)
        {
            var order = Context.Orders.Remove(obj);
            Context.SaveChanges();
            return order;
        }

        public Order Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}