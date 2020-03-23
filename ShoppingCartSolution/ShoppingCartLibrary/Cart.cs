
namespace ShoppingCartLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart
    {
        public string Id { get; set; }

        public CartStatus Status { get; set; }

        public double TotalPrice { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public virtual ICollection<Item> Items { get; set; }
    }
}
