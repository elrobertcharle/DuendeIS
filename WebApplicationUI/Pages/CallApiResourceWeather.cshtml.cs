using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationUI.Client;

namespace WebApplicationUI.Pages
{
    public class CallApiResourceWeatherModel : PageModel
    {
        private readonly WeatherClient _weatherClient;
        public CallApiResourceWeatherModel(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public string Json = string.Empty;

        public async Task OnGet()
        {
            Json = await _weatherClient.GetWeatherForecastAsync();
        }
    }
}
