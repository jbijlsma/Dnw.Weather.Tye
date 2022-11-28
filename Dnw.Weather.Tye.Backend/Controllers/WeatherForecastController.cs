using backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnw.Weather.Tye.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherDbContext _db;

    public WeatherForecastController(WeatherDbContext db)
    {
        _db = db;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _db.WeatherForecasts!.ToListAsync();
    }
}
