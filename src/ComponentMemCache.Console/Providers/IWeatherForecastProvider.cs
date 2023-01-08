using ComponentMemCache.Console.Models;

namespace ComponentMemCache.Console.Providers;

internal interface IWeatherForecastProvider
{
  Task<IEnumerable<WeatherForecast>> GetForecastsAsync(string key);
}