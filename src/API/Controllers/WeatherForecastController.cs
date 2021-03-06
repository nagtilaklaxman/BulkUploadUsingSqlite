using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WeatherForecastController : ApplicationController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger; 
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public Task<IActionResult> Get()
    {
        //var guid = Guid.NewGuid();
        //uploaderContext.SetDbPath("logs", Convert.ToString(guid));

        //await uploaderContext.ApplyMigration();

        var returnData = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        return Task.FromResult(Ok(returnData));
    }
}

