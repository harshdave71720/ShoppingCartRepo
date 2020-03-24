
namespace ShoppingCartLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public CartStatus Status { get; set; }

        public double TotalPrice { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public virtual ICollection<CartItem> CartItems { get; set; }

        public void PlaceOrder() { 
        
        }

        public int Add(Item item, int quantity) {
            if (CartItems == null)
            {
                CartItems = new List<CartItem> { new CartItem { Cart = this, Item = item, Quantity = quantity } };
                return quantity;
            }
             
            CartItem temp = CartItems.SingleOrDefault(c => c.Cart.Id.Equals(item.Id));
            //temp = ((List<CartItem>)CartItems).Find(ci => ci.Item.Id.Equals())
            if (temp != null) {
                temp.Quantity += quantity;
                return temp.Quantity;
            }
            CartItems.Add(new CartItem { Item = item, Cart = this, Quantity = quantity});
            return quantity;
        }

        public int Remove(Item item) {
            if (CartItems == null) {
                return 0;
            }

            CartItem temp = CartItems.SingleOrDefault(c => c.Cart.Id.Equals(item.Id));
            if (temp == null) {
                return 0;
            }
            temp.Quantity -= 1;
            if (temp.Quantity == 0) {
                CartItems.Remove(temp);
            }
            return temp.Quantity;
        }
    }
}
