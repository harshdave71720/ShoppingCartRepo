using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSystemWebAPI.Models
{
    public class UserItemModel
    {
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}