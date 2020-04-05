using Newtonsoft.Json;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSystemWebAPI.Models
{
    public class UserModel
    {
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 2)]
        [Required]
        public string Name { get; set; }

        [Required]
        [JsonProperty(Order = 3)]
        public string Email { get; set; }

        [Required]
        [JsonProperty(Order = 4)]
        public string Address { get; set; }

        public UserModel() { }

        public UserModel(User user) {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Address = user.Address;
        }

        public User ToUser() {
            return new User { Id = this.Id, Name = this.Name, Email = this.Email, Address = this.Address};
        }
    }
}