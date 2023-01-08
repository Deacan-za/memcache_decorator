using ComponentMemCache.Console.Models;

namespace ComponentMemCache.Console.Services;

internal sealed class WeatherForecastService : IWeatherForecastService
{
  private static readonly string[] Summaries = new[]
  {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  public async Task<IEnumerable<WeatherForecast>> GetAsync()
  {
    return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateTime.Now.AddDays(index),
      TemperatureCelsius = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
      .ToArray());
  }
}

internal interface IWeatherForecastService
{
  Task<IEnumerable<WeatherForecast>> GetAsync();
}