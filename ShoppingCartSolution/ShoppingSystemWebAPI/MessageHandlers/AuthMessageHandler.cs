using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Security.Principal;
using KeyBasedAuthenticator;
using System.Threading.Tasks;
using ShoppingCartDataLayer.Repositories;
using KeyBasedAuthenticator.DataBaseLayer;

namespace ShoppingSystemWebAPI.MessageHandlers
{
    public class AuthMessageHandler : DelegatingHandler
    {
        
        //private IDataSource UserDataSource;
        private IAuthRepository AuthUserRepository;
        public AuthMessageHandler(/*IDataSource source, */IAuthRepository repository) {
            //UserDataSource = source;
            AuthUserRepository = repository;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> userData = null;
            IEnumerable<string> authData = null;

            //check for apikey if not present log in as guest
            if (!request.Headers.TryGetValues("apikey", out userData)) {
                IPrincipal principal = new GenericPrincipal(new GenericIdentity("Guest"), new string[] { "Guest" });
                HttpContext.Current.User = principal;
                return await base.SendAsync(request, cancellationToken);
            }

            //check for Authorization data
            request.Headers.TryGetValues("Authorization", out authData);
            if (userData != null && (authData == null || authData.First() == null)) {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest,"authorization header missing");
            }
            
            var userId = userData.First();
            var authUser = AuthUserRepository.GetAppUser(Guid.Parse(userId));

            //user with wrong userid does not get access
            if (authUser == null) {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "authorization header missing");
            }

            //checking authorization data is complete
            if (authData.First().Split(':').Length < 2) {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "authorization header incomplete");                  
            }
            var temp = authData.First().Split(':');
            var rawData = temp[0];
            var hashSignature = temp[1];
            var privateKey = authUser.PrivateKey.ToString("N");
            var generatedSignature = HashSignatureGenerator.GenerateHash(rawData, authUser.PrivateKey.ToString("N"));
            if (! hashSignature.Equals(generatedSignature, StringComparison.Ordinal)) {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "User not authorized");
            }
            IPrincipal principal1 = new GenericPrincipal(new GenericIdentity(userId), new string[] { "User" });
            HttpContext.Current.User = principal1;
            return await base.SendAsync(request, cancellationToken);
        }
    }
}