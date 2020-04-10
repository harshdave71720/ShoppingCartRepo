using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyBasedAuthenticator.Models;

namespace ShoppingSystemWebAPI.Models
{
    public class AuthUserResultModel
    {
        public string PrivateKey { get; set; }

        public string PublicKey { get; set; }

        public AuthUserResultModel(AppUser user ) {
            PrivateKey = user.PrivateKey.ToString("N");
            PublicKey = user.Id.ToString("N");
        }
    }
}