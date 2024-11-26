namespace Aspire.CircularReference.Common
{
    public class ServiceClient
    {
        private readonly HttpClient _client;

        public ServiceClient(HttpClient client)
        {
            _client = client;
        }

        public Task<string> GetStringAsync(string? requestUri)
        {
            return _client.GetStringAsync(requestUri);
        }
    }
}
