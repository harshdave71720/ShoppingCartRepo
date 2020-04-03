using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class OrderItem
    {
        [Key, Column(Order = 0)]
        [JsonIgnore]
        public Guid OrderId { get; set; }

        [Key, Column(Order = 1)]
        public Guid ItemId { get; set; }

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [JsonIgnore]
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public int Quantity { get; set; }

        public ItemStatus Status { get; set; }

        public OrderItem(Order order, CartItem cartItem) {
            Item = cartItem.Item;
            //ItemId = cartItem.Item.Id;
            Order = order;
            //OrderId = order.Id;
            Quantity = cartItem.Quantity;
            //to be added status

        }
    }
}
