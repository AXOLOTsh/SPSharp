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
        public SPWorldsClient(CardAuthorization cardAuthorization, string baseUrl) : base(cardAuthorization, baseUrl) { }
        public SPWorldsClient(CardAuthorization cardAuthorization) : base(cardAuthorization) { }

        /// <summary>
        /// Checks payment.
        /// </summary>
        /// <param name="webhookUrl"></param>
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
        /// <param name="nickname"></param>
        /// <returns></returns>
        public async Task<string> GetUuidAsync(string nickname)
        {
            return await mojangClient.GetUuidAsync(nickname);
        }
    }

}
