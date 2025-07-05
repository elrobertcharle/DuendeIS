using Duende.IdentityModel.Client;

namespace ClientApi.Client
{
    public class DuendeClient
    {
        private readonly HttpClient _httpClient;

        public DuendeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5001");
        }

        public async Task<string> GetAccessToken()
        {
            var discoveryResponse = await _httpClient.GetDiscoveryDocumentAsync();
            if (discoveryResponse.IsError)
            {
                throw new Exception(discoveryResponse.Error);
            }
            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryResponse.TokenEndpoint,
                ClientId = "ClientApi1",
                ClientSecret = "Secret",
                Scope = "weather-forecast-api.read"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }


            return tokenResponse.AccessToken!;
        }
    }
}
