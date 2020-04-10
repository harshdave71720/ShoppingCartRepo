using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyBasedAuthenticator.Models
{
    public class AppUser
    {
        [JsonProperty(PropertyName = "ApiKey")]
        public Guid Id { get; set; }

        public Guid PrivateKey { get; set; }
    }
}