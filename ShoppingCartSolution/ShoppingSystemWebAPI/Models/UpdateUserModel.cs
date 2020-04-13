using Newtonsoft.Json;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSystemWebAPI.Models
{
    public class UpdateUserModel
    {
        [JsonProperty(Order = 1)]
        [Required]
        public Guid Id { get; set; }

        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public string Email { get; set; }

        [JsonProperty(Order = 4)]
        public string Address { get; set; }

        public User ToUser() {
            return new User { Name = this.Name, Address = this.Address, Email = this.Email, Id = this.Id};
        }
    }
}