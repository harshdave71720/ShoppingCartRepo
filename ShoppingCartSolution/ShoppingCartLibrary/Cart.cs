
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
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 3)]
        public CartStatus Status { get; set; }

        [JsonProperty(Order = 2)]
        public double TotalPrice { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        [JsonProperty(Order = 4)]
        public virtual ICollection<CartItem> CartItems { get; set; }

        public Cart() {

        }

        //private Cart() {
        //    this.CartItems = new List<CartItem>();
        //}

        public Cart(User user) : this() {
            this.User = user;
        }

        public Cart(User user, CartStatus status) : this(user) {
            this.Status = status;
        }

        public int Add(Item item, int quantity) {
            //if (item.Quantity < quantity)
            //{
            //    return -1;
            //}
            //item.Quantity -= quantity;
            if (quantity <= 0) {
                return 0;
            }
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
            CartItems.Add(new CartItem { Item = item, Cart = this, Quantity = quantity });
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
            if (quantity >= temp.Quantity) {             
                CartItems.Remove(temp);
                TotalPrice -= item.Price * temp.Quantity;
                return temp.Quantity;
            }
            //item.Quantity += quantity;
            temp.Quantity -= quantity;
            TotalPrice -= item.Price * quantity;
            //if (temp.Quantity <= 0) {
            //    CartItems.Remove(temp);
            //    return 
            //}
            return quantity;
        }

        public void EmptyCart() {
            throw new NotImplementedException("Method has to be implemented");
            //this.TotalPrice = 0;
            //CartItems = new ;
        }

        public Order PlaceOrder() {
            if (Status == CartStatus.Completed)
            {
                throw new InvalidOperationException("Cart is already completed");
            }
            if (CartItems == null || CartItems.Count == 0) {
                throw new InvalidOperationException("Cannot place empty order {The cart is empty}");
            }

            try {
                Validate();
            }
            catch (InvalidOperationException ex) {
                throw ex;
            }
            this.Status = CartStatus.Completed;

            if (this.Order != null)
            {
                this.Order.Update(this);
            }
            else {
                this.Order = new Order(this);
            }
            this.Order.UpdateStatus(OrderStatus.Active);
            return this.Order;
        }

        public void Validate() {
            foreach (var cartItem in CartItems)
            {
                if (cartItem.Quantity > cartItem.Item.Quantity)
                {
                    throw new InvalidOperationException(string.Format("{0} , Required Quantity : {1}, Available Quantity : {2}"
                        , cartItem.Item.Name, cartItem.Quantity, cartItem.Item.Quantity));
                }
            }
        }
    }
}
