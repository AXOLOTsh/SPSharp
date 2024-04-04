using SPSharp.Entities;
using SPSharp.Net;
using System.Security.Cryptography;
using System.Text;

namespace SPSharp
{
    /// <summary>
    /// Class for working with SPWorlds API.
    /// </summary>
    public class SPWorldsClient : SPWorldsApiClient
    {
        public SPWorldsClient(string token, string id) : base(token, id) { }
        public SPWorldsClient(string token, string id, string baseUrl) : base(token, id, baseUrl) { }
        public SPWorldsClient(CardAuthorization cardAuthorization, string baseUrl) : base(cardAuthorization, baseUrl) { }
        public SPWorldsClient(CardAuthorization cardAuthorization) : base(cardAuthorization) { }

        /// <summary>
        /// Checks payment.
        /// </summary>
        /// <param name="webhookUrl">The URL where SPWorlds sended a request to indicate successful payment.</param>
        /// <param name="xBodyHash"></param>
        /// <returns>Will return if payment has been made.</returns>
        public bool CheckPayment(string webhookUrl, string xBodyHash)
        {
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(CardAuthorization.Token)).ComputeHash(Encoding.UTF8.GetBytes(webhookUrl));
            return Convert.FromBase64String(xBodyHash).SequenceEqual(hash);
        }

        MojangApiClient mojangClient = new MojangApiClient();
        /// <summary>
        /// Get Profile UUID.
        /// </summary>
        /// <param name="nickname">Minecaft nickname./</param>
        /// <returns>UUID of minecraft profile.</returns>
        public async Task<string> GetUuidAsync(string nickname)
        {
            return await mojangClient.GetUuidAsync(nickname);
        }
    }

}
