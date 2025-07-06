using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebApplicationUI.Pages
{
    public class CallApiResourceWeatherModel : PageModel
    {
        public string Json = string.Empty;

        public async Task OnGet()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            Json = await client.GetStringAsync("https://localhost:7021/WeatherForecast");
        }
    }
}
