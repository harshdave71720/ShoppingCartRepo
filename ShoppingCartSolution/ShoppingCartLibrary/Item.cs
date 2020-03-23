using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class Item
    {
        public string Id { get; set; }

        public ItemStatus Status { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
