using ShoppingCartDataLayer.DataStores;
using ShoppingCartDataLayer.Factories;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    public class OrderManager
    {
        private OrderDataStore OrderStore;
        public OrderManager(OrderDataStore orderStore) {
            this.OrderStore = orderStore;
        }

        public Order GetOrder(Guid userId, Guid orderId)
        {
            return OrderStore.GetOrder(userId, orderId);
        }

        public List<Order> GetOrders(Guid userId)
        {
            var orders = OrderStore.GetOrders(userId);
            if (orders ==  null) {
                return new List<Order>();
            }
            return orders.ToList();
        }

        public bool ModifyOrder(Guid userId, Guid orderId)
        {            

            var order = OrderStore.GetOrder(userId, orderId);
            var orderItems = order.OrderItems.ToList();
            if (order == null)
            {
                throw new InvalidOperationException("Order does not exist");
            }
            if (order.Status == OrderStatus.Dispatched || order.Status == OrderStatus.Delivered)
            {
                throw new InvalidOperationException("Delivered or dispatched order cannot be modified");
            }
            if (order.Status == OrderStatus.Modifying)
            {
                throw new InvalidOperationException("Order already under modification ");
            }
            OrderStore.UpdateOrderPrice(order.Id, 0);
            OrderStore.EmptyOrder(order);
            ItemManager itemManager = new ItemManager(DataStoreFactory.CreateItemDataStore());
            foreach (var orderItem in orderItems) {
                itemManager.InCreaseItemQuantity(orderItem.ItemId, orderItem.Quantity);
            }

            OrderStore.UpdateOrderStatus(order.Id, OrderStatus.Modifying);
            DataStoreFactory.CreateCartDataStore().UpdateCartStatus(order.Id, CartStatus.Modifying);

            

            return true;
        }
        //public bool OrderItemDelivered(Guid userId, Guid orderId, Guid itemId) {
        //    var order = OrderStore.Orders.Find(new Order { Id = orderId});
        //    if (order == null || !order.User.Id.Equals(userId)) {
        //        return false;
        //    }
        //    var orderItem = order.OrderItems.FirstOrDefault(oi => oi.ItemId.Equals(itemId));
        //    if (orderItem == null) {
        //        return false;
        //    }
        //    orderItem.Status = ItemStatus.DELIVERED;
        //    return true;
        //}

        public Order AddOrder(Cart cart)
        {
            User user = new UserManager(DataStoreFactory.CreateUserDataStore()).GetUser(cart.UserId);
            if (user == null) {
                throw new OperationCanceledException("User not found (This is was unexpected)");
            }
            Order order = new Order
            {
                Id = cart.Id,
                Status = OrderStatus.Active,
                TotalPrice = cart.TotalPrice,
                UserId = cart.UserId,
                ShippingAddress = user.Address
            };
            AddItemsFromCart(order, cart);

            OrderStore.Add(order);
            return order;
        }

        public Order ConfirmOrder(Cart cart)
        {
            Order order = OrderStore.GetOrder(cart.UserId, cart.Id);
            if (order == null) {
                throw new InvalidOperationException("Order not found");
            }

            //AddItemsFromCart(order, cart);
            var orderItems = AddItemsFromCart(new Order(), cart).OrderItems;

            OrderStore.UpdateOrderStatus(cart.Id, OrderStatus.Active);
            OrderStore.UpdateOrderPrice(cart.Id, cart.TotalPrice);
            OrderStore.AddOrderItems(orderItems);

            return OrderStore.GetOrder(cart.UserId, order.Id);
        }

        public void CofirmDelivered(Guid orderId) {
            new CartManager(DataStoreFactory.CreateCartDataStore()).UpdateCartStatus(orderId, CartStatus.Completed);
            OrderStore.UpdateOrderStatus(orderId, OrderStatus.Delivered);
        }

        private Order AddItemsFromCart(Order order,Cart cart) {
            order.OrderItems = new List<OrderItem>();
            foreach (CartItem cartItem in cart.CartItems) {
                order.OrderItems.Add(
                    new OrderItem { 
                        ItemId = cartItem.ItemId, OrderId = cartItem.CartId, Quantity = cartItem.Quantity, Status = ItemStatus.PROCESSING
                    }
                );
            }
            return order;
        }
    }
}
