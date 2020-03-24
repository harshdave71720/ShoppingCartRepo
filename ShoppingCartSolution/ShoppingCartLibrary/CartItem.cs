using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartLibrary
{
    public class CartItem
    {
        [Key, Column(Order = 0)]
        public string CartId { get; set; }
        
        [Key, Column(Order = 1)]
        public string ItemId { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
