using Newtonsoft.Json;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSystemWebAPI.Models
{
    public class ItemModel
    {
        [JsonProperty(Order = 2)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 1)]
        [Required]
        public string Name { get; set; }

        [Required]
        [JsonProperty(Order = 3)]
        public int Quantity { get; set; }

        [Required]
        [JsonProperty(Order = 4)]
        public double Price { get; set; }

        public ItemModel() { }

        public ItemModel(Item item) {
            this.Id = item.Id;
            this.Name = item.Name;
            this.Price = item.Price;
            this.Quantity = item.Quantity;
            
        }

        public Item ToItem() {
            return new Item { Name = this.Name, Quantity = this.Quantity, Price = this.Price};
        }

    }
}