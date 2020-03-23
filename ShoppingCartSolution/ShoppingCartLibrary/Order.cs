using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class Order
    {
        public string Id { get; set; }

        public OrderStatus Status { get; set; }

        public string ShippingAddress { get; set; }
    }
}
