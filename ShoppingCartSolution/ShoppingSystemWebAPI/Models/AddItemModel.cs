using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingSystemWebAPI.Models
{
    public class AddItemModel
    {
        [Required]
        public Guid ItemId { get; set; }
        
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}