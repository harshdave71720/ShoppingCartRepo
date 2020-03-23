using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string  Email{ get; set; }
        public string Address { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
