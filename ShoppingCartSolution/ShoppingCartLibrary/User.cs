using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShoppingCartLibrary
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Email{ get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public void SubmitCart() {
            if (Carts == null || !Carts.Any(c => c.Status == CartStatus.Active))
                throw new InvalidOperationException("No Active Cart Found");

        }     

        public Cart GetActiveCart() {
            if (Carts == null)
            {
                Carts = new List<Cart> { new Cart(this, CartStatus.Active) };
                return Carts.First();
            }

            Cart cart = Carts.SingleOrDefault(c => c.Status == CartStatus.Active && c.Order == null);
            if (cart != null) {
                return cart;
            }
            cart = new Cart(this, CartStatus.Active);
            Carts.Add(cart);
            return cart;
        }

        

    }
}
