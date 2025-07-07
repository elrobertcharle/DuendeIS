namespace WebApplicationUI.Client;

public class WeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7021");
    }

    public async Task<string> GetWeatherForecastAsync()
    {
        return await _httpClient.GetStringAsync("WeatherForecast");
    }
}
