using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationUI.Pages
{
    public class CallApiResourceWeatherModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CallApiResourceWeatherModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string Json = string.Empty;

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("WeatherApi");
            Json = await httpClient.GetStringAsync("WeatherForecast");
        }
    }
}
