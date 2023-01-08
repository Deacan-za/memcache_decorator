using ComponentMemCache.Console.Models;
using ComponentMemCache.Console.Services;

namespace ComponentMemCache.Console.Providers;

internal sealed class BaseWeatherForecastProvider : IWeatherForecastProvider
{
  private readonly IWeatherForecastService _weatherForecastService;

  public BaseWeatherForecastProvider(IWeatherForecastService weatherForecastService)
  {
    _weatherForecastService = weatherForecastService;
  }

  public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(string key)
  {
    return await _weatherForecastService.GetAsync();
  }
}