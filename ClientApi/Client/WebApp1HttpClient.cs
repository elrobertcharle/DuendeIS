using Duende.IdentityModel.Client;

namespace ClientApi.Client
{
    public class WebApp1HttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly DuendeClient _duendeClient;

        public WebApp1HttpClient(HttpClient httpClient, DuendeClient duendeClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7021/");
            _duendeClient = duendeClient;
        }

        public async Task<string> Get()
        {
            var accessToken = await _duendeClient.GetAccessToken();
            _httpClient.SetBearerToken(accessToken);

            return await _httpClient.GetStringAsync("/WeatherForecast");
        }
    }
}
