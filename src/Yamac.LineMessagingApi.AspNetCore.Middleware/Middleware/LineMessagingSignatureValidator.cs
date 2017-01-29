using System;
using System.Security.Cryptography;
using System.Text;

namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    public class LineMessagingSignatureValidator
    {
        [ThreadStatic]
        private readonly HMACSHA256 sha256;

        public LineMessagingSignatureValidator(string channelSecret)
        {
            this.sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(channelSecret));
        }

        public bool ValidateSignature(byte[] content, string headerSignature)
        {
            var contentSignatureBytes = sha256.ComputeHash(content);
            var contentSignature = Convert.ToBase64String(contentSignatureBytes);
            return contentSignature == headerSignature;
        }
    }
}
