namespace Dnw.Weather.Tye.Frontend;

public class WeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
    {
        var forecasts = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
        return forecasts ?? Array.Empty<WeatherForecast>();
    } 
}