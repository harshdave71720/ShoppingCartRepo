using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ShoppingCartLibrary
{
    public class Order
    {
        
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }

        public string ShippingAddress { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [Required]
        public virtual Cart Cart { get; set; }

        //[Required]
        //public virtual ICollection<Item> Items { get; set; }
    }
}
