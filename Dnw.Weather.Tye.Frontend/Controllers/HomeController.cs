using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dnw.Weather.Tye.Frontend.Models;

namespace Dnw.Weather.Tye.Frontend.Controllers;

public class HomeController : Controller
{
    private readonly WeatherClient _weatherClient;

    public HomeController(WeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    public async Task<IActionResult> Index()
    {
        var forecasts = await _weatherClient.GetWeatherForecasts();
        return View(forecasts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
