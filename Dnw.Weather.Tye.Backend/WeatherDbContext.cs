using backend;
using Microsoft.EntityFrameworkCore;

namespace Dnw.Weather.Tye.Backend;

public class WeatherDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public WeatherDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     options.UseSqlite("Data Source=WeatherForecast.db");
    // }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     // in memory database used for simplicity, change to a real db for production applications
    //     options.UseInMemoryDatabase("TestDb");
    // }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var cn = _configuration.GetConnectionString("postgres");
        Console.WriteLine(cn);
        options.UseNpgsql(cn!);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.UtcNow.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        
        modelBuilder.Entity<WeatherForecast>().HasData(forecasts);
    }

    public DbSet<WeatherForecast>? WeatherForecasts { get; set; } = null!;
}