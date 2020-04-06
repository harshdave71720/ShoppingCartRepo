using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ShoppingCartLibrary
{
    public class Order
    {
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        private OrderStatus _status;

        [JsonProperty(Order = 2)]
        public OrderStatus Status { get; set; }
        //public OrderStatus Status { get {
        //        if (_status == OrderStatus.Modifying) {
        //            return _status;
        //        }
        //        int count = 0;
        //        foreach (var item in OrderItems) {
        //            if (item.Status == ItemStatus.) { 

        //            }
        //        }
        //    }
        //    set {
        //        _status = value;
        //    }
        //}

        [JsonProperty(Order = 3)]
        public string ShippingAddress { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [Required]
        [JsonIgnore]
        public virtual Cart Cart { get; set; }

        [JsonProperty(Order = 4)]
        public double TotalPrice { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        //[Required]
        //public virtual ICollection<Item> Items { get; set; }       

        public Order(Cart cart) {
            Id = cart.Id;
            User = cart.User;
            ShippingAddress = User.Address;
            Cart = cart;
            this.OrderItems = new List<OrderItem>();
            AddItemsFromCart(cart);
            TotalPrice = cart.TotalPrice;
            
        }

        private void ReleaseItems() {

            while (OrderItems.Count > 0) {
                var orderItem = OrderItems.FirstOrDefault();
                orderItem.Item.Quantity += orderItem.Quantity;
                OrderItems.Remove(orderItem);
            }
            OrderItems = null;
        }

        private void AddItemsFromCart(Cart cart) {
            if (OrderItems == null) {
                OrderItems = new List<OrderItem>();
            }
            foreach (var cartItem in cart.CartItems) {
                OrderItems.Add(new OrderItem(this, cartItem));
            }
        }

        public void Update(Cart cart) {
            ReleaseItems();
            AddItemsFromCart(cart);
        }

        public void UpdateStatus(OrderStatus status) {
            Status = status;
        }

        public void Modify() {
            if (Status == OrderStatus.Dispatched || Status == OrderStatus.Delivered) {
                throw new InvalidOperationException("Delivered or dispatched order cannot be modified");
            }
            if (Status == OrderStatus.Modifying) {
                throw new InvalidOperationException("Order already under modification ");
            }
            Status = OrderStatus.Modifying;
            Cart.Status = CartStatus.Active;
        }
        public Order() { }

    }
}
