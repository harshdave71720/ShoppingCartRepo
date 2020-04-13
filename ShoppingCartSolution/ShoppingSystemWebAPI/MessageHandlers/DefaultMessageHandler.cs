using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Principal;

namespace ShoppingSystemWebAPI.MessageHandlers
{
    public class DefaultMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity("User"), new string[] { "User"});              
            return base.SendAsync(request, cancellationToken);
        }
    }
}