using RestSharp;

namespace SPSharp.Net
{
    /// <summary>
    /// Base class for working with API.
    /// </summary>
    public abstract class BaseApiClient
    {
        //protected readonly HttpClient client = new HttpClient();
        protected readonly RestClient _client;

        /// <summary>
        /// Get BaseUrl
        /// </summary>
        public string BaseUrl { get; }

        public BaseApiClient(string baseUrl)
        {
            BaseUrl = baseUrl;
            _client = new RestClient(baseUrl);
            //client.BaseAddress = new Uri(BaseUrl);
        }

        /// <summary>
        /// Performs a GET request.
        /// </summary>
        public virtual async Task<string> GetRequestAsync(string request)
        {
            return _client.Execute(new RestRequest(request, Method.Get)).Content;
            /*var response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();*/
        }

        /// <summary>
        /// Performs a POST request.
        /// </summary>
        public virtual async Task<string> PostRequestAsync(string request, string content)
        {
            var req = new RestRequest(request, Method.Post);
            req.AddJsonBody(content);
            return _client.Execute(req).Content;
            /*var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(request, httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();*/
        }
    }
}
