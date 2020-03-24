﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Email{ get; set; }
        public string Address { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public ICollection<Order> Orders { get; set; }

        public void SubmitCart() {
            if (Carts == null || !Carts.Any(c => c.Status == CartStatus.Active))
                throw new InvalidOperationException("No Active Cart Found");

        }


    }
}
