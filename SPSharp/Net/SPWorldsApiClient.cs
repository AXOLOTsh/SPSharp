using RestSharp;
using SPSharp.Entities;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SPSharp.Net
{
    /// <summary>
    /// Class for working with the SPWorlds API.
    /// </summary>
    public class SPWorldsApiClient : BaseApiClient
    {
        public CardAuthorization CardAuthorization { get; }
        public SPWorldsApiClient(CardAuthorization cardAuthorization, string baseUrl = "https://spworlds.ru/api/public") : base(baseUrl)
        {
            CardAuthorization = cardAuthorization;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(Encoding.Default.GetBytes($"{cardAuthorization.Id}:{cardAuthorization.Token}")));
            _client.AddDefaultHeader("Authorization", $"Bearer {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{cardAuthorization.Id}:{cardAuthorization.Token}"))}");
        }

        /// <summary>
        /// The method returns the card balance.
        /// </summary>
        /// <returns>The balance that is on the card.</returns>
        public async Task<int> GetBalanceAsync()
        {
            var response = await GetRequestAsync("/card");
            var json = JsonNode.Parse(response);
            return (int)json["balance"];
        }

        /// <summary>
        /// The method returns the Minecraft player's nickname.
        /// </summary>
        /// <param name="discordId">Discord User Id can be obtained from the user's context menu (if developer options are enabled) or by copying (via the message context menu) a message that mentions the desired user.</param>
        /// <returns>The Minecraft player's nickname.</returns>
        public async Task<string> GetMinecraftNicknameAsync(ulong discordId) // добавить UUID и профили
        {
            var response = await GetRequestAsync($"/users/{discordId}");
            var json = JsonNode.Parse(response);
            return json["username"].ToString();
        }

        /// <summary>
        /// Method of transferring money from your card to another.
        /// </summary>
        /// <param name="receiver">Receiver's card number.</param>
        /// <param name="amount">Transfer amount.</param>
        /// <param name="comment">Commentary on the translation.</param>
        /// <returns></returns>
        public async Task SendPaymentAsync(string receiver, int amount, string comment)
        {
            var transaction = JsonSerializer.Serialize(new { receiver, amount, comment });
            await PostRequestAsync("/transactions", transaction);
        }

        /// <summary>
        /// Creates a payment request.
        /// </summary>
        /// <param name="amount">Amount to be paid.</param>
        /// <param name="redirectUrl">URL of the page to which the user will be redirected after payment.</param>
        /// <param name="webhookUrl">The URL where SPWorlds will send a request to indicate successful payment.</param>
        /// <param name="data">A line of up to 100 characters, you can put any useful data here.</param>
        /// <returns>Link to payment page.</returns>
        public async Task<string> CreatePaymentAsync(int amount, string redirectUrl, string webhookUrl, string data)
        {
            var payment = JsonSerializer.Serialize(new { amount, redirectUrl, webhookUrl, data });
            var response = await PostRequestAsync("/payment", payment);
            var json = JsonNode.Parse(response);
            return (string?)json["url"];
        }
    }
}
