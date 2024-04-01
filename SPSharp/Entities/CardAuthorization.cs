namespace SPSharp.Entities
{
    /// <summary>
    /// Class containing information for card authentication.
    /// </summary>
    public class CardAuthorization
    {
        public string Token { get; }
        public string Id { get; }
        public CardAuthorization(string token, string id)
        {
            Token = token;
            Id = id;
        }
    }
}
