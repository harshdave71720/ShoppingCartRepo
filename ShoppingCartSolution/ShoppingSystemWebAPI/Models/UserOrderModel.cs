using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingSystemWebAPI.Models
{
    public class UserOrderModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid OrderId { get; set; }
    }
}