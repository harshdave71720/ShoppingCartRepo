using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace KeyBasedAuthenticator
{
    public class HashSignatureGenerator
    {
        public static string GenerateHash(string rawData, string apiSecret) {
           
            var secretKeyByteArray = Convert.FromBase64String(apiSecret);

            byte[] encodedRawData = Encoding.UTF8.GetBytes(rawData);
            string signatureBase64String = null;
            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray)) {
                byte[] hashSignature = hmac.ComputeHash(encodedRawData);
                signatureBase64String = Convert.ToBase64String(hashSignature);
                
            }
            return signatureBase64String;
        }
    }
}
