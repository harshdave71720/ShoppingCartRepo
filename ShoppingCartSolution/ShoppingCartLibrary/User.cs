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
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }
        
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public string  Email{ get; set; }

        [JsonProperty(Order = 4)]
        public string Address { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cart> Carts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        //public void SubmitCart() {
        //    if (Carts == null || !Carts.Any(c => c.Status == CartStatus.Active))
        //        throw new InvalidOperationException("No Active Cart Found");

        //}     

        //public Cart GetActiveCart() {
        //    if (Carts == null)
        //    {
        //        Carts = new List<Cart> { new Cart(this, CartStatus.Active) };
        //        return Carts.First();
        //    }

        //    Cart cart = Carts.SingleOrDefault(c => c.Status == CartStatus.Active && c.Order == null);
        //    if (cart != null) {
        //        return cart;
        //    }
        //    cart = new Cart(this, CartStatus.Active);
        //    Carts.Add(cart);
        //    return cart;
        //}

        

    }
}
