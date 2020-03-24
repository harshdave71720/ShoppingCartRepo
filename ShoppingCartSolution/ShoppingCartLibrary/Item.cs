using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartLibrary
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public ItemStatus Status { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }

        public int Add(int quantity) {
            Quantity += quantity;
            return Quantity;
        }

        public int Remove(int quantity) {
            if (Quantity < quantity) {
                throw new InvalidOperationException("Items in available : " + Quantity + "Items to be removed : " + quantity);
            }
            Quantity -= quantity;
            return Quantity;
        }
    }
}
