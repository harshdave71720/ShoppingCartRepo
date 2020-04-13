using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDataLayer.DataStores
{
    public class OrderDataStore
    {
        private IOrderRepository OrderRepository;
        private IOrderItemRepository OrderItemRepository;
        public OrderDataStore(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository) {
            this.OrderRepository = orderRepository;
            this.OrderItemRepository = orderItemRepository;
        }

        public Order GetOrder(Guid userId, Guid orderId)
        {
            var order = OrderRepository.GetUserOrder(userId, orderId);
            if (order == null) {
                return null;
            }
            order.OrderItems = new List<OrderItem>();
            var orderItems = OrderItemRepository.GetAll(orderId).ToList();
            if (orderItems != null)
                order.OrderItems = orderItems;
            return order;
        }

        public void UpdateOrderStatus(Guid id, OrderStatus status)
        {
            OrderRepository.UpdateStatus(id, status);
        }

        public List<Order> GetOrders(Guid userId)
        {
            var orders = OrderRepository.GetAll().Where(o => o.UserId.Equals(userId)).ToList();

            foreach (var order in orders) {
                order.OrderItems = OrderItemRepository.GetAll(order.Id).ToList();
            }
            return orders;
        }

        public Order Add(Order order)
        {
            var orderItems = order.OrderItems;
            order.OrderItems = null;
            OrderRepository.Add(order);          
            foreach (OrderItem oi in orderItems) {
                OrderItemRepository.Add(oi);
            }
            order.OrderItems = orderItems;
            
            return order;
        }

        public void UpdateOrderPrice(Guid orderId, double price)
        {
            OrderRepository.UpdatePrice(orderId, price);   
        }

        public void EmptyOrder(Order order)
        {
            OrderItemRepository.RemoveAll(order.Id);
        }

        //public Order AddItemsToOrder(Guid id, List<OrderItem> orderItems)
        //{
        //    throw new NotImplementedException();
        //}

        public void AddOrderItems(ICollection<OrderItem> orderItems)
        {
            foreach (var orderItem in orderItems) {
                OrderItemRepository.Add(orderItem);
            }
        }
    }
}
