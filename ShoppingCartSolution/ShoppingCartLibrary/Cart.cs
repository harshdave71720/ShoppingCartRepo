
namespace ShoppingCartLibrary
{
    using Newtonsoft.Json;
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

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public Cart() { 

        }

        //private Cart() {
        //    this.CartItems = new List<CartItem>();
        //}

        public Cart(User user) : this(){        
            this.User = user;
        }

        public Cart(User user, CartStatus status) : this(user){
            this.Status = status;
        }


        public int Add(Item item, int quantity) {            
            if (item.Quantity < quantity) {
                return -1;
            }
            item.Quantity -= quantity;
            TotalPrice += item.Price * quantity;
            if (CartItems == null)
            {
                CartItems = new List<CartItem> { new CartItem { Cart = this, Item = item, Quantity = quantity } };
                return quantity;
            }
             
            CartItem temp = CartItems.SingleOrDefault(c => c.Item.Id.Equals(item.Id));
            //temp = ((List<CartItem>)CartItems).Find(ci => ci.Item.Id.Equals())
            if (temp != null) {
                temp.Quantity += quantity;
                return temp.Quantity;
            }
            CartItems.Add(new CartItem { Item = item, Cart = this, Quantity = quantity});
            return quantity;
        }

        public int Remove(Item item, int quantity) {
            if (CartItems == null) {
                return -1;
            }

            CartItem temp = CartItems.SingleOrDefault(c => c.Item.Id.Equals(item.Id));
            if (temp == null) {
                return -1;
            }
            item.Quantity += quantity;
            temp.Quantity -= quantity;
            TotalPrice -= item.Price * quantity;
            if (temp.Quantity == 0) {
                CartItems.Remove(temp);
            }
            return temp.Quantity;
        }

        public void EmptyCart() {
            foreach (CartItem cartItem in CartItems) {
                var item = cartItem.Item;
                item.Quantity += cartItem.Quantity;
                cartItem.Quantity = 0;
            }
            this.TotalPrice = 0;
            //CartItems = null;
        }

        public Order PlaceOrder() {
            if (Status == CartStatus.Completed || this.Order != null) {
                return null;
            }
            this.Status = CartStatus.Completed;
            this.Order = new Order { 
                Id = this.Id,
                Cart = this, 
                ShippingAddress = this.User.Address,
                Status = OrderStatus.Recieved,
                User = this.User 
            };
            return Order;
        }
    }
}
