using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartLibrary
{
    public class Order
    {
        public string Id { get; set; }

        public OrderStatus Status { get; set; }

        public string ShippingAddress { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Cart Cart { get; set; }

        [Required]
        public virtual ICollection<Item> Items { get; set; }
    }
}
