﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ShoppingCartLibrary
{
    public class CartItem
    {
        [Key, Column(Order = 0)]
        [JsonIgnore]
        public Guid CartId { get; set; }
        
        [Key, Column(Order = 1)]
        public Guid ItemId { get; set; }

        [JsonIgnore]
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        [JsonIgnore]
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
