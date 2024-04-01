namespace SPSharp.Net
{
    // Not finished!
    /// <summary>
    /// Class for working with Mojang API.
    /// </summary>
    public class MojangApiClient : BaseApiClient
    {
        public MojangApiClient() : base("https://api.mojang.com") { }

        /// <summary>
        /// Gets the UUID for a given username.
        /// </summary>
        public async Task<string> GetUuidAsync(string username)
        {
            string request = $"/users/profiles/minecraft/{username}";
            return await GetRequestAsync(request);
        }
    }
}
