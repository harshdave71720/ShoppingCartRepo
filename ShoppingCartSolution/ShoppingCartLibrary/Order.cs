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

        [JsonProperty(Order = 2)]
        public OrderStatus Status { get; set; }

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
            foreach (CartItem cartItem in cart.CartItems) {
                OrderItems.Add(new OrderItem(this, cartItem));
            }
            TotalPrice = cart.TotalPrice;
            
        }
        public Order() { }

    }
}
