
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

        public virtual User User { get; set; }
    }
}
