using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ShoppingCartLibrary
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(Order = 2)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        //[JsonProperty(Order = 5)]
        //public ItemStatus Status { get; set; }
        
        [JsonProperty(Order = 3)]
        public int Quantity { get; set; }

        [JsonProperty(Order = 4)]
        public double Price { get; set; }

        [JsonIgnore]
        public virtual ICollection<CartItem> CartItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        //public int Add(int quantity) {
        //    Quantity += quantity;
        //    return Quantity;
        //}

        //public int Remove(int quantity) {
        //    //if (Quantity < quantity) {
        //    //    throw new InvalidOperationException("Items in available : " + Quantity + "Items to be removed : " + quantity);
        //    //}
        //    if (Quantity < quantity) {
        //        var temp = Quantity;
        //        Quantity = 0;
        //        return temp;
        //    }
        //    Quantity -= quantity;
        //    return Quantity;
        //}
    }
}
